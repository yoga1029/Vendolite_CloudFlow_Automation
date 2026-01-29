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
using VMS_Phase1PortalAT.FlowTest.Product.Subcategories;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.Product.Categories
{
    public class AddCategory
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        public AddCategory(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void AddCategoryFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Adding Categories");
            try
            {
                Thread.Sleep(1000);
                //Locate Product Module
                IWebElement productModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Products')]")));
                productModule.Click();

                //Locate Category sub-module
                IWebElement categorySubModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),' Categories ')]")));
                categorySubModule.Click();
                Thread.Sleep(2000);


                for (int i = 0; i < AddCategoryData.Categories.GetLength(0); i++)
                {
                    string searchName = AddCategoryData.Categories[i, 0];
                    IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                    searchText.Clear();
                    searchText.SendKeys(searchName + Keys.Enter);
                    Thread.Sleep(5000);

                    // Check if category exists
                    var rows = driver.FindElements(By.XPath("//table//tbody/tr"));
                    Thread.Sleep(1000);
                    if (rows.Count == 0)
                    {
                        Console.WriteLine($"Category '{searchName}' not found. Adding category");


                        // Navigate to add catgeory page
                        IWebElement addCategoryButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                        addCategoryButton.Click();
                        Thread.Sleep(2000);

                        //Fill the input fields
                        IWebElement categoryName = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
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
                        IWebElement imageUploadBtn = wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                        imageUploadBtn.SendKeys(AddCategoryData.Categories[i, 4]);

                        driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                        Thread.Sleep(3000);



                    }
                }

                AddSubCategory subcategory = new AddSubCategory(driver);
                subcategory.AddSubCategoryFlow();
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
