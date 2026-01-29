using AventStack.ExtentReports;
using AventStack.ExtentReports.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;
using VMS_Phase1PortalAT.FlowTest.Warehouse.WarehouseList;

namespace VMS_Phase1PortalAT.FlowTest.Product.ProductList
{
    public class AddProduct
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        public AddProduct(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddProductFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Adding New Products");
            try
            {
                Thread.Sleep(1000);
                //Locate Product Module
                IWebElement productModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Products')]")));
                productModule.Click();

                //Locate ProductList sub-module
                IWebElement productList = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),' Product List ')]")));
                productList.Click();
                Thread.Sleep(5000);

                for (int i = 0; i < AddProductData.Products.GetLength(0); i++)
                {

                    IWebElement branchFilter = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'branch']")));
                    branchFilter.Click();
                    Thread.Sleep(2000);

                    IWebElement selectBranch = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains (text(), ' Pudukkottai Branch ')]")));
                    selectBranch.Click();
                    Thread.Sleep(2000);

                    string searchName = AddProductData.Products[i, 0];
                    IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                    searchText.Clear();
                    searchText.SendKeys(searchName + Keys.Enter);
                    Thread.Sleep(3000);

                    // Check if product exists
                    var rows = driver.FindElements(By.XPath("//table//tbody/tr"));
                    if (rows.Count == 0)
                    {
                        Console.WriteLine($"Product '{searchName}' not found. Adding Product");

                        // Navigate to add product page
                        IWebElement addProductButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                        addProductButton.Click();
                        Thread.Sleep(2000);

                        //Fill the input fields

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name"))).SendKeys(AddProductData.Products[i, 1]);
                        Thread.Sleep(2000);

                        //wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@placeholder = 'Branch'])[2]"))).Click();
                        //string branchName = AddProductData.Products[i, 2];
                        //string dynamicBranchXPath = $"//span[text()=' {branchName} ']";
                        //driver.FindElement(By.XPath(dynamicBranchXPath)).Click();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("(//input[@placeholder = 'Branch'])[2]"))).Click();
                        string branchName = AddProductData.Products[i, 2];
                        driver.FindElement(By.XPath($"//span[text()=' {branchName} ']")).Click();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("brand"))).Click();
                        string brandName = AddProductData.Products[i, 3];
                        string dynamicBrandXPath = $"//span[text()=' {brandName} ']";
                        driver.FindElement(By.XPath(dynamicBrandXPath)).Click();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("category"))).Click();
                        string categoryName = AddProductData.Products[i, 4];
                        string dynamicCategoryXPath = $"//span[text()=' {categoryName} ']";
                        driver.FindElement(By.XPath(dynamicCategoryXPath)).Click();

                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("subcategory"))).Click();
                        string subcategoryName = AddProductData.Products[i, 5];
                        string dynamicSubcategoryXPath = $"//span[text()=' {subcategoryName} ']";
                        driver.FindElement(By.XPath(dynamicSubcategoryXPath)).Click();

                        IWebElement productId = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("customProductId")));
                        productId.SendKeys(AddProductData.Products[i, 6]);
                        Thread.Sleep(2000);

                        IWebElement hsnCode = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("hsnCode")));
                        hsnCode.SendKeys(AddProductData.Products[i, 7]);
                        Thread.Sleep(2000);

                        bool sp = true;
                        if (AddProductData.Products[i, 10] == "1")
                        {
                            IWebElement addGstCheckbox = wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@name='addGST']")));
                            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
                            js.ExecuteScript("arguments[0].click();", addGstCheckbox);
                            Thread.Sleep(1000);

                            sp = false;
                            IWebElement maximumRetailPrice = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("mrp")));
                            maximumRetailPrice.SendKeys(AddProductData.Products[i, 11]);
                            Thread.Sleep(2000);

                            IWebElement cgst = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("cgst")));
                            cgst.SendKeys(AddProductData.Products[i, 12]);
                            Thread.Sleep(2000);

                            IWebElement sgst = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("sgst")));
                            sgst.SendKeys(AddProductData.Products[i, 13]);
                            Thread.Sleep(2000);

                            IWebElement utgst = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("utgst")));
                            utgst.SendKeys(AddProductData.Products[i, 14]);
                            Thread.Sleep(1000);

                            IWebElement cess = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("cess")));
                            cess.SendKeys(AddProductData.Products[i, 15]);
                            Thread.Sleep(1000);

                            IWebElement costForState = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("sCost")));
                            costForState.SendKeys(AddProductData.Products[i, 16]);
                            Thread.Sleep(2000);

                            IWebElement costForUt = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("utCost")));
                            costForUt.SendKeys(AddProductData.Products[i, 17]);
                            Thread.Sleep(2000);

                            //Taxable price for state and ut will be automatically calculated 
                        }
                        if (sp)
                        {
                            IWebElement sellingPrice = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("cost")));
                            sellingPrice.SendKeys(AddProductData.Products[i, 8]);
                            Thread.Sleep(2000);
                        }

                        // Upload Product Image
                        IWebElement imageUploadBtn = wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                        imageUploadBtn.SendKeys(AddProductData.Products[i, 9]);


                        driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                        Thread.Sleep(3000);

                        driver.FindElement(By.XPath("//button//span[contains(text(),'Cancel')]")).Click();
                        Thread.Sleep(3000);


                    }
                }

                Console.WriteLine($"Moving to AddWarehouse");
                AddWarehouse warehouseList = new AddWarehouse(driver);
                warehouseList.AddWarehouseFlow();
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