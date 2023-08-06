using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTrustAssignment.Pages
{
    public class WeatherDataPage 

    {
        private IWebDriver driver;
        BasePage basepage;
        HomePage homepage;

        public WeatherDataPage(IWebDriver driver)
        {

            this.driver = driver;
        }

        IList<IWebElement> MenuOptions => driver.FindElements(By.XPath("//div[@class='row justify-content-center mt-3 mb-3']/div/div[1]"));

        String Temp => driver.FindElement(By.XPath("//div[@class='row justify-content-center mt-3 mb-3']/div/div[1]/following-sibling::div")).Text;
        public String VerifyWeatherDataForSelectedCity(String City)
        {   
            WebDriverWait wait=new WebDriverWait(driver,TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//h3[text()='Weather History for ']")));
            String Header = driver.FindElement(By.XPath("//h3[text()='Weather History for ']/a")).Text;
            Console.WriteLine(Header);
            return Header;
           //Assert.AreEqual(City, Header.Trim());
        }
        public void GetTempforSelectedCity(String City)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='row justify-content-center mt-3 mb-3']/div")));
            for(int i = 0; i < MenuOptions.Count; i++)
            {
                Console.WriteLine(MenuOptions[i].Text +" of " +City+ " is " +Temp);
            }

        }
    }
}
