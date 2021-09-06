
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace avitela.Page
{
    public class BasicCheckBoxPage : BasePage
    {

        private const string PageAddress = "https://www.seleniumeasy.com/test/basic-checkbox-demo.html";

        private IWebElement singleCheckBox => Driver.FindElement(By.Id("isAgeSelected"));

        private IWebElement singleCheckBoxMessage => Driver.FindElement(By.Id("txtAge"));

        private const string SingleCheckBoxMessageText = "Success - Check box is checked";

        private IReadOnlyCollection<IWebElement> _multipleCheckBoxes => Driver.FindElements(By.ClassName("cb1-element"));

        private IWebElement checkAllButton => Driver.FindElement(By.Id("check1"));


        public BasicCheckBoxPage(IWebDriver webdriver) : base(webdriver)
        { }

        public BasicCheckBoxPage NavigateToPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public BasicCheckBoxPage CheckSingleCheckBox()
        {
            if (!singleCheckBox.Selected)
                singleCheckBox.Click();
            return this;
        }

        public BasicCheckBoxPage UnCheckSingleCheckBox()
        {
            if (singleCheckBox.Selected)
                singleCheckBox.Click();
            return this;
        }

        public BasicCheckBoxPage AssertSingleCheckBoxDemoSuccessMessage()
        {

            Assert.AreEqual(SingleCheckBoxMessageText, singleCheckBoxMessage.Text, "tekstas nesutampa!");

            return this;
        }

        [System.Obsolete]
        public BasicCheckBoxPage AssertSingleCheckBoxDemoSuccessMessageWithWait()
        {
            GetWait(2).Until(ExpectedConditions.TextToBePresentInElement(singleCheckBoxMessage, SingleCheckBoxMessageText));
            Assert.AreEqual(SingleCheckBoxMessageText, singleCheckBoxMessage.Text, "tekstas nesutampa!");

            return this;
        }


        public BasicCheckBoxPage CheckAllMultipleCheckBoxes()
        {
            foreach (IWebElement singleCheckbox in _multipleCheckBoxes)
            {
                if (!singleCheckbox.Selected)
                    singleCheckbox.Click();
            }
            return this;
        }

        [System.Obsolete]
        public BasicCheckBoxPage AssertButtonName(string expectedName)
        {

            GetWait().Until(ExpectedConditions.TextToBePresentInElementValue(checkAllButton, expectedName));
            Assert.AreEqual(expectedName, checkAllButton.GetAttribute("value"), "Wrong button label");
            return this;
        }


        public BasicCheckBoxPage ClickGroupButton()
        {
            checkAllButton.Click();
            return this;
        }

        public BasicCheckBoxPage AssertMultipleCheckBoxesUnchecked()
        {
            foreach (IWebElement singleCheckbox in _multipleCheckBoxes)
            {
                Assert.False(singleCheckbox.Selected, "One of checkboxes is still checked!");
            }

            return this;
        }

    }
}
