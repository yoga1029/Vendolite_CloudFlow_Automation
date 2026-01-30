using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Company.Client;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.Company.Branch
{
    public class AddBranch
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        public AddBranch(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        public void AddBranchFlow()
        {

            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Adding Branch");
            try
            {
                Thread.Sleep(2000);
                //Locate Company Module
                IWebElement companyModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("menuItem-Company")));
                companyModule.Click();

                ////Locate branch sub-module
                //IWebElement branchListSubModule = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Branch List')]")));
                //branchListSubModule.Click();
                //Thread.Sleep(2000);


                string searchName = AddBranchData.addBranchSuccess["searchName"];
                IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);
                Thread.Sleep(3000);

                // Check if branch exists
                var rows = driver.FindElements(By.XPath("//table//tbody/tr"));
                if (rows.Count == 0)
                {
                    Console.WriteLine($"Branch '{searchName}' not found. Adding Branch");

                    // Navigate to add branch page
                    IWebElement addBranchButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(@class,'add_fab')]")));
                    addBranchButton.Click();
                    Thread.Sleep(2000);

                    //Fill the input fields
                    IWebElement name = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
                    name.SendKeys(AddBranchData.addBranchSuccess["name"]);

                    IWebElement location = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("location")));
                    location.SendKeys(AddBranchData.addBranchSuccess["location"]);

                    IWebElement code = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("code")));
                    code.SendKeys(AddBranchData.addBranchSuccess["code"]);

                    IWebElement email = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("email")));
                    email.SendKeys(AddBranchData.addBranchSuccess["email"]);

                    IWebElement contactDetails = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("contactDetails")));
                    contactDetails.SendKeys(AddBranchData.addBranchSuccess["contactDetails"]);

                    IWebElement gstNo = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("gstNo")));
                    gstNo.SendKeys(AddBranchData.addBranchSuccess["gstNo"]);

                    IWebElement address = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("address")));
                    address.SendKeys(AddBranchData.addBranchSuccess["address"]);

                    IWebElement companyName = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyName")));
                    companyName.SendKeys(AddBranchData.addBranchSuccess["companyName"]);

                    IWebElement companyContactNo = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyContactNo")));
                    companyContactNo.SendKeys(AddBranchData.addBranchSuccess["companyContactNo"]);

                    IWebElement companyEmail = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyEmail")));
                    companyEmail.SendKeys(AddBranchData.addBranchSuccess["companyEmail"]);

                    IWebElement companyAddress = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("companyAddress")));
                    companyAddress.SendKeys(AddBranchData.addBranchSuccess["companyAddress"]);
                    Thread.Sleep(3000);


                    // Upload Branch Image
                    IWebElement branchLogo = wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                    branchLogo.SendKeys(AddBranchData.addBranchSuccess["fileUpload"]);

                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                    Thread.Sleep(4000); //Save button

                    //// Edit Company Name of branch 
                    //IWebElement actionButtonOfAddBranch1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Click here')]")));
                    //actionButtonOfAddBranch1.Click();
                    //Thread.Sleep(2000);

                    //IWebElement editButtonOfAddBranch = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (text(), 'Edit')]")));
                    //editButtonOfAddBranch.Click();
                    //Thread.Sleep(2000);

                    //driver.FindElement(By.Name("companyName")).SendKeys("e");
                    //Thread.Sleep(1000);

                    //driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                    //Thread.Sleep(2000);

                    //// Delete Branch
                    //IWebElement actionButtonOfAddBranch2 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Click here')]")));
                    //actionButtonOfAddBranch2.Click();
                    //Thread.Sleep(2000);

                    //IWebElement deleteButtonOfAddBranch = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (text(), 'Delete')]")));
                    //deleteButtonOfAddBranch.Click();
                    //Thread.Sleep(2000);

                    //IWebElement confirmDelete = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains (text(), 'Confirm')]")));
                    //confirmDelete.Click();
                    //Thread.Sleep(2000);

                    //AddClient client = new AddClient(driver);
                    //client.AddClientFlow();

                }
                else
                {
                    Console.WriteLine($"Branch '{searchName}' already exists. Moving to AddClient");
                    AddClient client = new AddClient(driver);
                    client.AddClientFlow();
                }
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