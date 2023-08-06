using InterTrustAssignment.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterTrustAssignment.StepDefinitions
{
    [Binding]
    internal class QueryBuilderSteps
    {
        private IWebDriver driver;
        BasePage basePage;
        HomePage homepage;
        WeatherDataPage weatherDataPage;
        QueryBuilderPage queryBuilderPage;


        public QueryBuilderSteps(IWebDriver driver)
        {
            this.driver = driver;
        }
        [When(@"I Click on WeatherAPI Menu and search for the given '([^']*)'")]
        public void WhenIClickOnWeatherAPIMenuAndSearchForTheGiven(string City)

        { 
             homepage = new HomePage(driver);
            //weatherDataPage=homePage.ClickOnWeatcherDataMenu(City);
            queryBuilderPage= homepage.VerifyDailyReport(City);
            //Thread.Sleep(80000);
        }


        [Then(@"I should be able to see the daily Report of the selected '([^']*)'")]
        public void ThenIShouldBeAbleToSeeTheDailyReportOfTheSelected(string City)
        {
           queryBuilderPage.VeriifyDailyReportData(City);
           //queryBuilderPage.HourlyDateValues();
        }

    }
}
