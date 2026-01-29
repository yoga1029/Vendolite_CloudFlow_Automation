using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using VMS_Phase1PortalAT.FlowTest.Authentication;

namespace VMS_Phase1PortalAT.FlowTest.Machines.MachineList
{
    //[TestClass]
    public class MachineScrapping
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        public static string unmappedMachineForMapping;
        //Report Generating
        private static ExtentReports extent;
        private static ExtentTest test;


        public MachineScrapping(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(70));
        }

        /*[TestInitialize]
            public void Setup()
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(20));
            } */

        //[TestMethod]
        public void MachineScrappingFlow()
        {

            extent = ExtentManager.GetInstance();
            test = extent.CreateTest("Scrapping the Machine");
            try
            {
                ////Login
                //var login = new Login(driver);
                //login.CompanyLoginSuccess();
                //Thread.Sleep(2000);

                Thread.Sleep(2000);
                //var expandedMenus = driver.FindElements(By.XPath("//div[contains(@class,'menuItemMain') and contains(@class,'active')]"));
                //foreach (var menu in expandedMenus)
                //{
                //    try
                //    {
                //        ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", menu);
                //        Thread.Sleep(300);
                //        menu.Click();     // collapse
                //        Thread.Sleep(400);
                //    }
                //    catch { }
                //}

                //// Navigate to Purchase Order menu
                //IWebElement purchaseOrder = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[normalize-space()='Purchase Order']/parent::div")));
                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", purchaseOrder);
                //Thread.Sleep(300);
                //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", purchaseOrder);   // JS Click (safe click)
                //Thread.Sleep(600);

                // Navigate to Current Purchase Order submenu
                IWebElement currentPurchaseOrderMenu = wait.Until(ExpectedConditions.ElementExists(By.XPath("//div[contains(text(),'Current Purchase Order')]")));
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView({block:'center'});", currentPurchaseOrderMenu);
                Thread.Sleep(300);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", currentPurchaseOrderMenu);
                Thread.Sleep(2000);


                //Search Machine to Scrap
                IWebElement searchTypeButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//mat-select[@role = 'listbox'])[2]")));
                searchTypeButton.Click();
                Thread.Sleep(2000);

                IWebElement selectMachineId = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[contains(normalize-space(),'Machine Id')]")));
                selectMachineId.Click();
                Thread.Sleep(2000);

                string machineId = /*"2VE0000220" */ MachineMapping.unmappedMachineForMapping;
                Console.WriteLine("Selecting machine: " + machineId);

                IWebElement searchMachine = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//input[@name = 'searchText']")));
                searchMachine.Clear();
                searchMachine.SendKeys(/*MachineMapping.unmappedMachineForMapping */ machineId + Keys.Enter);
                Thread.Sleep(2000);

                IWebElement actionButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//td)[13]")));
                actionButton.Click();
                Thread.Sleep(1000);

                IWebElement scarpButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button[contains(text(),' Move to scrap ')]")));
                scarpButton.Click();
                Thread.Sleep(2000);

                IWebElement comfirmScrapping = wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//button//span[contains(text(),' Confirm ')]")));
                comfirmScrapping.Click();
                Thread.Sleep(2000);

                Console.WriteLine("The Machine is Scrapped: " + machineId);
                test.Pass();
            }
            catch (Exception ex)
            {
                test.Fail(ex);
            }
            extent.Flush();
            driver.Quit();
        }
    }
}


