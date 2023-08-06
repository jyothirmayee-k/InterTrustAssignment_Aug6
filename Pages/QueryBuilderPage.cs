using FluentAssertions.Formatting;
using InterTrustAssignment.Features;
using Microsoft.VisualBasic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Globalization;

namespace InterTrustAssignment.Pages
{
    public class QueryBuilderPage
    {
        private IWebDriver driver;

        public QueryBuilderPage(IWebDriver _driver)
        {
            driver = _driver;
        }
        //IWebElement WeatherAPIMenu => driver.FindElement(By.LinkText("Weather API"));

        IWebElement WeatherApIMenu => driver.FindElement(By.LinkText("Weather API"));

        IWebElement SearchText => driver.FindElement(By.Id("querylocation"));

        IWebElement SearchButton => driver.FindElement(By.XPath("//button[text()='Create Query']"));

        IList<IWebElement> ReportOptions => driver.FindElements(By.XPath("(//div[@class='btn-group'])[2]"));

        IWebElement GridButton => driver.FindElement(By.XPath("//span[text()=' Grid']"));

        IWebElement DailyReportButton => driver.FindElement(By.XPath("//span[normalize-space()='Daily']"));

        IWebElement DailyReportTable => driver.FindElement(By.XPath("//table[@class='table table-striped fs-xs']"));
        WebDriverWait wait => new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        IJavaScriptExecutor jse => (IJavaScriptExecutor)driver;

        IWebElement selecteddate => driver.FindElement(By.XPath("//table[@class='table table-striped fs-xs']/tbody/tr/th"));
        IWebElement HourlyButton => driver.FindElement(By.XPath("//span[normalize-space()='Hourly']/.."));
       
        IWebElement PopupClose => driver.FindElement(By.XPath("(//div[@class='modal-content']/div[3]/button[text()='Close'])[2]"));
        public void VeriifyDailyReportData(String City)
        {
            try
            {

                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//div[@class='modal-header']/h5[text()='Welcome to Weather Query Builder!']")));
                PopupClose.Click();
                String date = driver.FindElement(By.XPath("(//div[@class='flex items-center'])[1]/button")).Text;
                string[] dateval = date.Split('/');
                String converteddate = (dateval[2] + "-" + dateval[0] + "-" + dateval[1]);
                Console.WriteLine("Start Date =" + converteddate);
                wait.Until(ExpectedConditions.ElementToBeClickable(By.XPath("//span[normalize-space()='Grid']")));
                GridButton.Click();
                jse.ExecuteScript("window.scrollBy(0,400)");
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//table[@class='table table-striped fs-xs']")));
                IList<IWebElement> tablerows = driver.FindElements(By.XPath("//table[@class='table table-striped fs-xs']/tbody/tr"));
                Console.WriteLine("Total Rows : " + tablerows.Count);
                for (int i = 0; i < tablerows.Count; i++)
                {

                    IList<IWebElement> Columns = tablerows[i].FindElements(By.TagName("td"));
                    Console.WriteLine("Total Columns : " + Columns.Count);
                    // Console.WriteLine(Columns[0].Text);
                    for (int j = 0; j < Columns.Count; j++)
                    {
                        if (Columns[j].Text.Equals(converteddate))
                        {
                            IList<IWebElement> FirstRowdata = tablerows[i].FindElements(By.XPath("td"));

                            foreach (IWebElement row in FirstRowdata)
                            {
                                Console.WriteLine(row.Text);

                            }
                            Columns[j].Click();


                            break;

                        }
                        break;


                    }
                    break;




                }
                wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//span[normalize-space()='Hourly']/..")));
                HourlyButton.Click();
                String Title = driver.Title;
                Assert.AreEqual(selecteddate.Text, converteddate);
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                driver.Quit();
            }
        }
        

    }
}
