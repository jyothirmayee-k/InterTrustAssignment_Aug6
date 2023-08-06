using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace InterTrustAssignment.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks
        private IObjectContainer _container;
        public Hooks(IObjectContainer container)
        { 
            _container = container;
        }  
        [BeforeScenario("@tag1")]
        public void BeforeScenarioWithTag()
        {
           
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            //TODO: implement logic that has to run after executing each scenario
            var driver = _container.Resolve<IWebDriver>();
            if(driver != null) { driver.Quit(); }
        }
    }
}