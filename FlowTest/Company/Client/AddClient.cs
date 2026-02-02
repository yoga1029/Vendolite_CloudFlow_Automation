using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.Company.Client
{
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
            // ===== Click Company Module safely =====
            By companyModuleBy = By.Id("menuItem-Company");
            wait.Until(d => d.FindElement(companyModuleBy).Displayed);
            driver.FindElement(companyModuleBy).Click();

            // ===== Click Client sub-menu safely =====
            By clientMenuBy = By.Id("menuItem-Company1");
            wait.Until(d => d.FindElement(clientMenuBy).Displayed);
            driver.FindElement(clientMenuBy).Click();

            Thread.Sleep(2000);

            for (int i = 0; i < AddClientData.Clients.GetLength(0); i++)
            {
                string searchName = AddClientData.Clients[i, 0];

                By searchBoxBy = By.Name("searchText");
                wait.Until(d => d.FindElement(searchBoxBy).Displayed);
                var searchText = driver.FindElement(searchBoxBy);
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);

                Thread.Sleep(2000);

                var rows = driver.FindElements(By.XPath("//table//tbody/tr"));

                if (rows.Count == 0)
                {
                    Console.WriteLine($"Client '{searchName}' not found. Adding Client");

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

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]"))
                          .Click();

                    Thread.Sleep(2000);
                }
                else
                {
                    Console.WriteLine($"Client '{searchName}' already exists.");
                }
            }
        }
    }
}
