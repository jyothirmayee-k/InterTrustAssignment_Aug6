using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTrustAssignment.Pages
{
    public  class BasePage
    {
        BasePage basepage;
        HomePage homepage;
        private IWebDriver driver;
        public BasePage(IWebDriver _driver)
        {
            this.driver = _driver;
            

        }
        ////public HomePage LaunchApplication()
        //{
        //    driver = new ChromeDriver();
        //    driver.Url = "https://www.visualcrossing.com/";
        //    driver.Manage().Window.Maximize();
        //    driver.FindElement(By.XPath("//button[text()='Accept all cookies']")).Click();
        //    return new HomePage(driver);


        //}
    }
}
