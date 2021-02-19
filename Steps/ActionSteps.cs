using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    class ActionSteps 
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

    }
}
