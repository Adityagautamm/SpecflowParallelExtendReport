using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SpecFlowProject1.Pages;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    class ActionSteps : AllPageBase
    {

        private readonly ScenarioContext _scenarioContext;
        public ActionSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        //[When(@"I navigate to (.*) page")]
        [Given(@"I navigate to (.*) page")]
        public void GivenINavigateToPage(string pageName)
        {
            // setting the object
            BaseSteps.SetObject(pageName);

            // Getting the object and directing to the URL
            BaseSteps.NavigateToUrl(BaseSteps.GetStoredPageUrl());

        }

        [When(@"I click on (.*) element")]
        public void WhenIClickOnElement(string elementName)
        {
            // Getting the element
           IWebElement element= BaseSteps.GetWebElement(elementName);
            BaseSteps.ClickELement(element);
        }

        [When(@"I save the value of (.*) element as alias (.*)")]
        public void WhenISaveTheValueOfElementAsAlias(string elementName, string aliasName)
        {
            // Getting the element
            IWebElement element = BaseSteps.GetWebElement(elementName);
            _scenarioContext.Add(aliasName, element.Text);
        }


        [When(@"I click on (.*) from list of elements (.*)")]
        public void WhenIClickOnFromListOfElements(string text, string elements)
        {
            IWebElement target = BaseSteps.ExtractWebElementFromElements(BaseSteps.GetWebElements(elements), text);

            target.Click();
        }

        [When(@"I enter text (.*) on the element (.*)")]
        public void WhenIEnterTextOnTheElement(string text, string elementName)
        {
            if (text.Equals("space"))
            {
                text = string.Empty; 
            }
            IWebElement element = BaseSteps.GetWebElement(elementName);
            BaseSteps.SendInfoToELement(element, text);

        }

        [When(@"I select (.*) from dropdown (.*)")]
        public void WhenISelectFromDropdown(string text, string elementName)
        {
            IWebElement dropDown = BaseSteps.GetWebElement(elementName);
            SelectElement selectedValue = new SelectElement(dropDown);
            selectedValue.SelectByText(text);
        }

        [When(@"I accept the alert")]
        public void WhenIAcceptTheAlert()
        {
            var alert = driver.SwitchTo().Alert();
            // if present consume the alert
            alert.Accept();
        }

        [When(@"I enter text (.*) in the alert")]
        public void WhenIEnterTextInTheAlert(string text)
        {
            var alert = driver.SwitchTo().Alert();
            // if present consume the alert
            alert.SendKeys(text);
        }


    }
}
