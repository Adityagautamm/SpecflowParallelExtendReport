using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectV2.Pages
{
    class AlertPage : AllPageBase
    {

        public string url => "https://the-internet.herokuapp.com/javascript_alerts";

        public IWebElement JsAlert => driver.FindElement(By.XPath("//button[contains (@onclick, 'jsAlert()')]"));

        public IWebElement JsConfirm => driver.FindElement(By.XPath("//button[contains (@onclick, 'jsConfirm()')]"));

        public IWebElement JsPrompt => driver.FindElement(By.XPath("//button[contains (@onclick, 'jsPrompt()')]"));

        public IWebElement AlertMessage => driver.FindElement(By.Id("result"));

    }
}
