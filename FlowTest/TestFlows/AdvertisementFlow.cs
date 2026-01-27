using DocumentFormat.OpenXml.Office2019.Drawing.SVG;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VMS_Phase1PortalAT.FlowTest.Authentication;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;
using WindowsInput;
using WindowsInput.Native;

namespace VMS_Phase1PortalAT.FlowTest.TestFlows
{
    [TestClass]
    public class Advertisement
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public static string unmappedMachineForMapping;


        //public Advertisemen(IWebDriver driver)
        //{
        //    this.driver = driver;
        //    wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        //}

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        }

        [TestMethod]
        public void AdvertisementFlow()
        {
            //Login
            var login = new Login(driver);
            login.CompanyLoginSuccess();
            Thread.Sleep(2000);

            // Navigate to Advertisement menu
            IWebElement advertisementButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),'Advertisements')]")));
            advertisementButton.Click();
            Thread.Sleep(2000);

            // Navigate to List submenu
            IWebElement listMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),' List ')]")));
            listMenu.Click();
            Thread.Sleep(2000);

            for (int i = 0; i < AddAdvertisementData.adds.GetLength(0); i++)
            {

                string searchName = AddAdvertisementData.adds[i, 0];
                IWebElement searchText = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
                searchText.Clear();
                searchText.SendKeys(searchName + Keys.Enter);
                Thread.Sleep(2000);

                var rowData = driver.FindElements(By.XPath("//table//tbody/tr"));    //fetching table data
                if (rowData.Count == 0)
                {
                    Console.WriteLine($"Advertisement '{searchName}' not found. Adding Advertisement");
                    IWebElement addAdvertisement = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Add Advertisement')]")));
                    addAdvertisement.Click();
                    Thread.Sleep(1000);

                    IWebElement adTitle = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("name")));
                    adTitle.SendKeys(AddAdvertisementData.adds[i, 0]);


                    IWebElement selectContentType = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("contentType")));
                    selectContentType.Click();


                    IWebElement choosingFileType = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath($"//div[contains(@class,'cdk-overlay-pane')]//span[contains(text(), '{AddAdvertisementData.adds[i, 1]}')]")));
                    choosingFileType.Click();
                    Thread.Sleep(1000); 
                    // Upload Category Image
                    IWebElement uploadBtn = wait.Until(ExpectedConditions.ElementExists(By.Id("fileUpload")));
                    uploadBtn.SendKeys(AddAdvertisementData.adds[i, 3]);


                    //// Simulate typing file path + Enter
                    //var sim = new InputSimulator();
                    //sim.Keyboard.TextEntry(@"");
                    //sim.Keyboard.KeyPress(VirtualKeyCode.RETURN);
                    //Thread.Sleep(3000);


                    IWebElement client = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Client']")));
                    client.Click();
                    Thread.Sleep(1000);

                    IWebElement clientName = wait.Until(ExpectedConditions.ElementToBeClickable(
                           By.XPath($"//div[contains(@class,'cdk-overlay-pane')]//mat-option//span[normalize-space()='{AddAdvertisementData.adds[i, 2]}']")));
                    clientName.Click();
                    Thread.Sleep(1000);
                    driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                    Thread.Sleep(5000);
                }
                else
                {
                    Console.WriteLine("Moving to Map the Addvertisement to Client");
                }

                // Navigate to Mapping submenu
                IWebElement mappingMenu = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//div[contains(text(),' Mapping ')]")));
                mappingMenu.Click();
                Thread.Sleep(2000);

                IWebElement addAdvertisement1 = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains (@mattooltip, 'Add Advertisement')]")));
                addAdvertisement1.Click();
                Thread.Sleep(1000);

                IWebElement choosingClient = wait.Until(ExpectedConditions.ElementToBeClickable(
                       By.XPath($"//div[contains(@class,'cdk-overlay-pane')]//mat-option//span[normalize-space()='{AddAdvertisementData.adds[i, 2]}']")));
                choosingClient.Click();
                Thread.Sleep(1000);

                IWebElement machine = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@placeholder='Machine ID']")));
                machine.Click();
                Thread.Sleep(1000);

                IWebElement choosingMachine = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath($"//div[contains(@class,'cdk-overlay-pane')]//mat-option//span[normalize-space()='{AddAdvertisementData.adds[i, 4]}']")));
                choosingMachine.Click();
                Thread.Sleep(1000);

                IWebElement selectAdvertisement = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("advertisementId")));
                selectAdvertisement.Click();

                IWebElement adDropdown = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.XPath($"//div[contains(@class,'cdk-overlay-pane')]//span[contains(text(), '{AddAdvertisementData.adds[i, 5]}')]")));
                adDropdown.Click();

                //IWebElement statusFlag = wait.Until(ExpectedConditions.ElementToBeClickable(
                //    By.XPath("//input[@role='switch']")));
                //statusFlag.Click();

                IWebElement statusFlag = wait.Until(ExpectedConditions.ElementToBeClickable(
                    By.ClassName("mat-slide-toggle")));
                statusFlag.Click();

                driver.FindElement(By.XPath("//button//span[contains(text(),'Save')]")).Click();
                Thread.Sleep(5000);
                Console.WriteLine("Advertisement Mapped to the Client");

                IWebElement searchTypeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//mat-select[@role = 'listbox'])[2]")));
                searchTypeButton.Click();
                Thread.Sleep(2000);

                IWebElement selectName = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains (text(), ' Machine Id ')]")));
                selectName.Click();
                Thread.Sleep(2000);

                string searchMachine = AddAdvertisementData.adds[i, 4];
                IWebElement SearchMachine = wait.Until(ExpectedConditions.ElementToBeClickable(By.Name("searchText")));
                SearchMachine.Clear();
                SearchMachine.SendKeys(searchMachine + Keys.Enter);
                Thread.Sleep(2000);

                IWebElement actionButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[10]")));
                actionButton.Click();
                Thread.Sleep(1000);


                //Set as Default
                string defaultMachine = AddAdvertisementData.adds[i, 4];
                IWebElement setasDefault = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath($"//button[contains(text(),' Set as default for {defaultMachine}')]")));
                setasDefault.Click();
                Thread.Sleep(3000);
                Console.WriteLine("The advertisement is set as default for this machine.");
            }
        }
    

        [TestCleanup]
            public void TearDown()
            {
                driver.Quit();
            }
    } 
}
