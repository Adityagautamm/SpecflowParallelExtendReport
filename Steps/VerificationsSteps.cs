
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    class VerificationsSteps
    {

        private readonly ScenarioContext _scenarioContext;
        public VerificationsSteps(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }


        [Then(@"I Verify the element (.*) to be equal to alias (.*)")]
        public void WhenIVerifyTheElementToBeEqualToAlias(string elementName, string aliasName)
        {

            // Getting the element
            IWebElement element = BaseSteps.GetWebElement(elementName);
            string elementValue = BaseSteps.ReadELement(element);
            string aliasValue = (string)_scenarioContext[aliasName];

           Assert.IsTrue(elementValue.Contains(aliasValue));
        }

        [Then(@"I am on the (.*) page")]
        public void ThenIAmOnThePage(string pageName)
        {
            // setting the object
            BaseSteps.SetObject(pageName);

            // Getting the object and directing to the URL
            string storedUrl = BaseSteps.GetStoredPageUrl();

            string currentPageUrl = BaseSteps.GetUrl();

            Assert.IsTrue(storedUrl.Contains(currentPageUrl));
        }

    }
}
