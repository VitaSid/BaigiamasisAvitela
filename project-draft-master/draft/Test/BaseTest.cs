

using avitela.Drivers;
using avitela.Page;
using avitela.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace avitela.Test
{
    public class BaseTest
    {
        public static IWebDriver driver;
        public static BasicCheckBoxPage _page;
        public static AvitelaHomePage _avitelaHomePage;
        public static AvitelaSearchResultPage _avitelaSearchResultPage;


        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _avitelaHomePage = new AvitelaHomePage(driver);
            _avitelaSearchResultPage = new AvitelaSearchResultPage(driver);
            _page = new BasicCheckBoxPage(driver);
        }

        //[TearDown]
        //public static void TakeScreeshot()
        //{
        //    if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
        //        MyScreenshot.MakeScreeshot(driver);
        //}

        [OneTimeTearDown]
        public static void TearDown()
        {
            //driver.Quit();
        }
    }
}

