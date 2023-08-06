using InterTrustAssignment.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTrustAssignment.StepDefinitions
{
    [Binding]
    
    public class HomePageSteps
    {
        IWebDriver driver;
        BasePage basePage;
        HomePage homepage;
        WeatherDataPage weatherDataPage;

        public HomePageSteps(IWebDriver driver)
        {
            this.driver=driver;
        }


        [Given(@"I login to the application")]
        public void GivenILoginToTheApplication()
        {
            HomePage homePage = new HomePage(driver);
            homePage.LaunchApplication();
        }

        [When(@"I click on WeatherData to enter the '([^']*)' and hit search")]
        public void WhenIClickOnWeatherDataToEnterTheAndHitSearch(string City)
        {
            HomePage homePage = new HomePage(driver);
            weatherDataPage=homePage.ClickOnWeatcherDataMenu(City);
        }
       
        [When(@"I should be navigated to WeatherDataResults page for the '([^']*)'")]
        public void WhenIShouldBeNavigatedToWeatherDataResultsPageForThe(string City)
        {
           String ReportResultCity= weatherDataPage.VerifyWeatherDataForSelectedCity(City);
           Assert.AreEqual(City, ReportResultCity.Trim());
        }
              
        [Then(@"I should be able to see the weatcher Data of '([^']*)'")]
        public void ThenIShouldBeAbleToSeeTheWeatcherDataOf(string City)
        {
            weatherDataPage.GetTempforSelectedCity(City);
        }



    }
}
