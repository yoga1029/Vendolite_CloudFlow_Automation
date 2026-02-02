using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.Company.Branch
{
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

            // ===== Click Company Module safely =====
            By companyModuleBy = By.Id("menuItem-Company");
            wait.Until(d => d.FindElement(companyModuleBy).Displayed);
            driver.FindElement(companyModuleBy).Click();

            // ===== Click Branch List safely =====
            By branchListBy = By.XPath("//div[contains(text(),'Branch List')]");
            wait.Until(d => d.FindElement(branchListBy).Displayed);
            driver.FindElement(branchListBy).Click();

            Thread.Sleep(2000);

            string searchName = AddBranchData.addBranchSuccess["searchName"];

            By searchBoxBy = By.Name("searchText");
            wait.Until(d => d.FindElement(searchBoxBy).Displayed);
            var searchText = driver.FindElement(searchBoxBy);
            searchText.Clear();
            searchText.SendKeys(searchName + Keys.Enter);

            Thread.Sleep(3000);

            var rows = driver.FindElements(By.XPath("//table//tbody/tr"));

            if (rows.Count == 0)
            {
                Console.WriteLine($"Branch '{searchName}' not found. Adding Branch");

                By addBranchBtnBy = By.XPath("//button[contains(@class,'add_fab')]");
                wait.Until(d => d.FindElement(addBranchBtnBy).Displayed);
                driver.FindElement(addBranchBtnBy).Click();

                Thread.Sleep(2000);

                driver.FindElement(By.Name("name"))
                      .SendKeys(AddBranchData.addBranchSuccess["name"]);

                driver.FindElement(By.Name("location"))
                      .SendKeys(AddBranchData.addBranchSuccess["location"]);

                driver.FindElement(By.Name("code"))
                      .SendKeys(AddBranchData.addBranchSuccess["code"]);

                driver.FindElement(By.Name("email"))
                      .SendKeys(AddBranchData.addBranchSuccess["email"]);

                driver.FindElement(By.Name("contactDetails"))
                      .SendKeys(AddBranchData.addBranchSuccess["contactDetails"]);

                driver.FindElement(By.Name("gstNo"))
                      .SendKeys(AddBranchData.addBranchSuccess["gstNo"]);

                driver.FindElement(By.Name("address"))
                      .SendKeys(AddBranchData.addBranchSuccess["address"]);

                driver.FindElement(By.Name("companyName"))
                      .SendKeys(AddBranchData.addBranchSuccess["companyName"]);

                driver.FindElement(By.Name("companyContactNo"))
                      .SendKeys(AddBranchData.addBranchSuccess["companyContactNo"]);

                driver.FindElement(By.Name("companyEmail"))
                      .SendKeys(AddBranchData.addBranchSuccess["companyEmail"]);

                driver.FindElement(By.Name("companyAddress"))
                      .SendKeys(AddBranchData.addBranchSuccess["companyAddress"]);

                Thread.Sleep(3000);

                IWebElement branchLogo = wait.Until(
                    ExpectedConditions.ElementExists(By.Id("fileUpload"))
                );
                branchLogo.SendKeys(AddBranchData.addBranchSuccess["fileUpload"]);

                driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]"))
                      .Click();

                Thread.Sleep(4000);
            }
            else
            {
                Console.WriteLine($"Branch '{searchName}' already exists.");
            }
        }
    }
}
