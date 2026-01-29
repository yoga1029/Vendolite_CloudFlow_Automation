using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS_Phase1PortalAT.FlowTest.Product.Categories;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;
using WindowsInput;
using WindowsInput.Native;



namespace VMS_Phase1PortalAT.FlowTest.Product.Brand
{
    public class AddBrand
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;

        public AddBrand(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddBrandFlow()
        {
            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Adding Brand");
            try
            {
                Thread.Sleep(2000);
                //Locate Product Module
                IWebElement productModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Products')]")));
                productModule.Click();

                //Locate brand sub-module
                IWebElement brandListSubModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),' Brand ')]")));
                brandListSubModule.Click();
                Thread.Sleep(4000);

                for (int i = 0; i < AddBrandData.Brands.GetLength(0); i++)
                {

                    string searchName = AddBrandData.Brands[i, 0];
                    IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                    searchText.Clear();
                    searchText.SendKeys(searchName + Keys.Enter);
                    Thread.Sleep(3000);

                    // Check if brand exists
                    var rows = driver.FindElements(By.XPath("//table//tbody/tr"));
                    if (rows.Count == 0)
                    {
                        Console.WriteLine($"Brand '{searchName}' not found. Adding brand");

                        // Click Add button
                        IWebElement addBrandButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                        addBrandButton.Click();
                        Thread.Sleep(2000);

                        //Fill the input fields
                        IWebElement brandName = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
                        brandName.SendKeys(AddBrandData.Brands[i, 1]);


                        driver.FindElement(By.Name("branch")).Click();
                        string branchName = AddBrandData.Brands[i, 2];
                        string dynamicXPath = $"//span[text()=' {branchName} ']";
                        driver.FindElement(By.XPath(dynamicXPath)).Click();

                        // Upload Brand Image
                        IWebElement imageUploadBtn = wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                        imageUploadBtn.SendKeys(AddBrandData.Brands[i, 3]);

                        driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                        Thread.Sleep(3000);


                    }
                }
                AddCategory category = new AddCategory(driver);
                category.AddCategoryFlow();
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
