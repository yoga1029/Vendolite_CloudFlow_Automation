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
using VMS_Phase1PortalAT.FlowTest.Product.ProductList;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.Product.Subcategories
{
    public class AddSubCategory
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        public AddSubCategory(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void AddSubCategoryFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Adding SubCategories");
            try
            {
                Thread.Sleep(1000);
                //Locate Product Module
                IWebElement productModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Products')]")));
                productModule.Click();

                //Locate Subategory sub-module
                IWebElement subCategory = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),' Sub Categories ')]")));
                subCategory.Click();
                Thread.Sleep(3000);


                for (int i = 0; i < AddSubCategoryData.SubCategory.GetLength(0); i++)
                {
                    string searchName = AddSubCategoryData.SubCategory[i, 0];
                    IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                    searchText.Clear();
                    searchText.SendKeys(searchName + Keys.Enter);
                    Thread.Sleep(5000);
                    var rows = driver.FindElements(By.XPath("//table//tbody/tr"));
                    if (rows.Count == 0)
                    {
                        Console.WriteLine($"Subcategory '{searchName}' not found. Adding Subcategory");


                        // Navigate to add subcatgeory page
                        IWebElement addSubCategoryButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                        addSubCategoryButton.Click();
                        Thread.Sleep(2000);

                        // Fill the input fields using 2D array
                        wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name"))).SendKeys(AddSubCategoryData.SubCategory[i, 1]);

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

                        // Upload Category Image
                        IWebElement imageUploadBtn = wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                        imageUploadBtn.SendKeys(AddSubCategoryData.SubCategory[i, 5]);

                        ////Fill the input fields
                        //IWebElement brand = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("brand")));
                        //brand.Click();
                        //Thread.Sleep(1000);

                        //IWebElement chooseBrandName = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[text() = ' Chro ']")));
                        //chooseBrandName.Click();
                        //Thread.Sleep(1000);

                        driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                        Thread.Sleep(3000);
                    }
                }
                Console.WriteLine($"Moving to AddProduct");
                AddProduct productList = new AddProduct(driver);
                productList.AddProductFlow();
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
