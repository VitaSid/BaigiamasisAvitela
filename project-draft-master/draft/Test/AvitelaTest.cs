using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace avitela.Test
{
    class AvitelaTest : BaseTest
    {
        [Test]
        public static void TestPriceFilter()
        {
            _avitelaHomePage.NavigateToPage();
            _avitelaHomePage.CloseCookies();
            _avitelaHomePage.SearchByText("jura");
            _avitelaSearchResultPage.OrderByHighestPrice();
            _avitelaSearchResultPage.InsertMinPrice("300");
            _avitelaSearchResultPage.InsertMaxPrice("800");
            _avitelaSearchResultPage.PressEnter();
            _avitelaSearchResultPage.CheckFilteringResults();

        }

       
    }
}
