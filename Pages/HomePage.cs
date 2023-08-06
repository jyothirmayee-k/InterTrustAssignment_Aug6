using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterTrustAssignment.Pages;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using NUnit.Framework;

namespace InterTrustAssignment.Pages
{
    

    public class HomePage 
    { 
        private IWebDriver driver;
        BasePage basepage;
        HomePage homepage;
      
      public  HomePage(IWebDriver driver) 
        {
          
            this.driver = driver; 
        }

        IWebElement WeatherDataMenu => driver.FindElement(By.LinkText("Weather Data"));
            
        IWebElement searchtext => driver.FindElement(By.Id("wxlocation"));

        IWebElement searchbutton => driver.FindElement(By.XPath("//button[text()='Search']"));

        IWebElement WeatherApIMenu => driver.FindElement(By.LinkText("Weather API"));

        IWebElement SearchText => driver.FindElement(By.Id("querylocation"));

        IWebElement SearchButton => driver.FindElement(By.XPath("//button[text()='Create Query']"));

        WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(20));
        IJavaScriptExecutor jse => (IJavaScriptExecutor)driver;


        public void LaunchApplication()
        {
            driver.Url= "https://www.visualcrossing.com/";
            driver.FindElement(By.XPath("//button[text()='Accept all cookies']")).Click();
        }
        public WeatherDataPage ClickOnWeatcherDataMenu(String City)
        {
            
            wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("(//a[text()='Weather Data'])[1]")));
            WeatherDataMenu.Click();
            jse.ExecuteScript("window.scrollBy(0,400)");
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[text()='Search']")));
            searchtext.SendKeys(City);
            searchbutton.Click();
            return new WeatherDataPage(driver);
            
        }

        public QueryBuilderPage VerifyDailyReport(String City)
        {
            WeatherApIMenu.Click();
            SearchText.SendKeys(City);
            SearchButton.Click();
            return new QueryBuilderPage(driver);

        }


    }

}
