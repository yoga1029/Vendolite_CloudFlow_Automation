using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Threading;
using VMS_Phase1PortalAT.FlowTest.Utilities.Datas;

namespace VMS_Phase1PortalAT.FlowTest.Authentication
{
    public class Login
    {
        IWebDriver driver;
        WebDriverWait wait;

        // Constructor to pass driver from test files
        public Login(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(50));
        }

        public void CompanyLoginSuccess()
        {
            //login to portal
            IWebElement login = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("username")));
            login.SendKeys(LoginData.loginSuccess["username"]);

            IWebElement password = wait.Until(ExpectedConditions.ElementIsVisible(By.Name("password")));
            password.SendKeys(LoginData.loginSuccess["password"]);

            IWebElement loginButton = wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("button.mat-raised-button")));
            loginButton.Click();
            Thread.Sleep(2000);
        }
    }
}