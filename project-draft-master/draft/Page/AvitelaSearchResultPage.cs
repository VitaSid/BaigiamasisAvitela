using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avitela.Page
{
    public class AvitelaSearchResultPage : BasePage
    {
        private const string orderByHighestPriceText = "Kaina (Aukšta > Žema)";

        IReadOnlyCollection<IWebElement> FilteredProducts => Driver.FindElements(By.XPath("//span[@class='price-new']"));
        private IWebElement minPriceRange => Driver.FindElement(By.XPath("//input[@name='bfp_price_min']"));
        private IWebElement maxPriceRange => Driver.FindElement(By.XPath("//input[@name='bfp_price_max']"));        
        private SelectElement OrderByDropdown => new SelectElement(Driver.FindElement(By.XPath("//*[@id='mfilter-content-container']/div[1]/div[2]/div/select")));
        public AvitelaSearchResultPage(IWebDriver webdriver) : base(webdriver)  { }

        public void OrderByHighestPrice()
        {
            OrderByDropdown.SelectByText(orderByHighestPriceText);
        }

        public void InsertMinPrice(string minPrice)
        {
            minPriceRange.Clear();
            minPriceRange.SendKeys(minPrice);
        }

        public void InsertMaxPrice(string maxPrice)
        {
            GetWait();
            maxPriceRange.Clear();
            GetWait();
            maxPriceRange.SendKeys(maxPrice);            
        }

        public void PressEnter()
        {
            GetWait();
            Actions action = new Actions(Driver);
            action.SendKeys(Keys.Enter);            
            action.Build().Perform();
        }
                
        public void CheckFilteringResults()
        {            
             IWebElement firstResultElement = FilteredProducts.First();
             IWebElement LastResultElement = FilteredProducts.Last();

            GetWait();

            string firstResultElementPrice = firstResultElement.Text;
            string lastResultElementPrice = LastResultElement.Text;

            firstResultElementPrice = firstResultElementPrice.Replace("€", string.Empty);
            firstResultElementPrice = firstResultElementPrice.Replace(",", ".");
            lastResultElementPrice = lastResultElementPrice.Replace("€", string.Empty);
            lastResultElementPrice = lastResultElementPrice.Replace(",", ".");

            decimal highestPriceDecimal = decimal.Parse(firstResultElementPrice, NumberStyles.Currency);
            decimal lowestPriceDecimal = decimal.Parse(lastResultElementPrice, NumberStyles.Currency);

            GetWait();
            string getMaxPriceRange = maxPriceRange.GetAttribute("value");
            string getMinPriceRange = minPriceRange.GetAttribute("value");

            int _getMaxPriceRange = int.Parse(getMaxPriceRange);
            int _getMinPriceRange = int.Parse(getMinPriceRange);

            GetWait();            
            Assert.GreaterOrEqual(lowestPriceDecimal, _getMinPriceRange, "badly filtered ");
            Assert.LessOrEqual(highestPriceDecimal, _getMaxPriceRange, "badly filtered ");

        }





    }
}
