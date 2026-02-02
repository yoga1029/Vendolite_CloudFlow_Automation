//using AventStack.ExtentReports;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using OpenQA.Selenium;
//using OpenQA.Selenium.Chrome;
//using System;
//using VMS_Phase1PortalAT.FlowTest.Authentication;
//using VMS_Phase1PortalAT.FlowTest.Company.Branch;
//using VMS_Phase1PortalAT.FlowTest.Company.Client;
//using VMS_Phase1PortalAT.FlowTest.Machines.MachineList;
//using VMS_Phase1PortalAT.FlowTest.Product.Brand;
//using VMS_Phase1PortalAT.FlowTest.Product.Categories;
//using VMS_Phase1PortalAT.FlowTest.Product.ProductList;
//using VMS_Phase1PortalAT.FlowTest.Product.Subcategories;


//namespace VMS_Phase1PortalAT.FlowTest.TestFlows
//{
//    [TestClass]
//    public class TestFlow
//    {
//        private IWebDriver driver;
//        //Report Generating
//        private static ExtentReports extent;
//        private static ExtentTest test;

//        [TestInitialize]
//        public void Setup()
//        {
//            driver = new ChromeDriver();
//            driver.Manage().Window.Maximize();
//            driver.Navigate().GoToUrl("https://cloud-test.vendolite.com/");
//        }

//        [TestMethod]
//        public void EndToEndFlow()
//        {

//            extent = ExtentManager.GetInstance();
//            test = extent.CreateTest("Entering in to Login Page");
//            try
//            {
//                //Login
//                var login = new Login(driver);
//                login.CompanyLoginSuccess();

//                //Add Branch
//                var branch = new AddBranch(driver);
//                branch.AddBranchFlow();
//                Thread.Sleep(5000);
//                test.Pass();
//            }
//            catch (Exception ex)
//            {
//                test.Fail(ex);
//            }
//            extent.Flush();

//            ////Add Client
//            //var client = new AddClient(driver);
//            //client.AddClientFlow();
//            //Thread.Sleep(5000);

//            ////Machine Mapping
//            //var machineMapping = new MachineMapping(driver);
//            //machineMapping.ClientMappingWithMachineFlow();
//            //Thread.Sleep(5000);

//            ////Raise Refill Request
//            //var refill = new RaiseRefillRequest(driver);
//            //refill.RaiseRefillRequestFlow();


//            ////Machine Module Flow
//            //var machineList = new Machine(driver);
//            //machineList.MachineModuleFlow();


//            ////Add Brand 
//            //var brand = new AddBrand(driver);
//            //brand.AddBrandFlow();
//            //Thread.Sleep(5000);

//            ////Add Category
//            //var category = new AddCategory(driver);
//            //category.AddCategoryFlow();
//            //Thread.Sleep(5000);

//            ////Add SubCategory
//            //var subCategory = new AddSubCategory(driver);
//            //subCategory.AddSubCategoryFlow();
//            //Thread.Sleep(5000);

//            ////Add Product
//            //var productList = new AddProduct(driver);
//            //productList.AddProductFlow();
//            //Thread.Sleep(3000);
//        }

//        [TestCleanup]
//        public void TearDown()
//        {
//            driver.Quit();
//        }
//    }
//}
