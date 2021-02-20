using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectV2.Pages
{
    class ComputersPage : AllPageBase
    {

        public string url => "http://computer-database.gatling.io/computers";

        public IList<IWebElement> ComputerNames => driver.FindElements(By.XPath("//*[@id='main']/table/tbody/tr/td/a"));

        public IWebElement Name => driver.FindElement(By.Id("name"));

        public IWebElement Save => driver.FindElement(By.XPath("//input[contains(@value, 'Save this computer')]"));

        public IWebElement Delete => driver.FindElement(By.XPath("//input[contains(@value, 'Delete this computer')]"));

        public IWebElement AlertMessage => driver.FindElement(By.XPath("//div[contains(@class,'alert-message warning')]"));

        public IWebElement FailMessage => driver.FindElement(By.XPath("//input[@id='name']/following-sibling::span"));

        public IWebElement Introduced => driver.FindElement(By.Id("introduced"));

        public IWebElement Discontinued => driver.FindElement(By.Id("discontinued"));

        public IWebElement IntroducedErrorMessage => driver.FindElement(By.XPath("//input[@id='introduced']/ parent::div/span[contains (@class, 'help-inline')]"));

        public IWebElement DiscontinuedErrorMessage => driver.FindElement(By.XPath("//input[@id='discontinued']/ parent::div/span[contains (@class, 'help-inline')]"));

        public IWebElement Company => driver.FindElement(By.Id("company"));

        public IWebElement AddComputer => driver.FindElement(By.Id("add"));

    }
}
