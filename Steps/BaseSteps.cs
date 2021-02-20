using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Steps
{
    [Binding]
    class BaseSteps : AllPageBase
    {
        public static Actions actions;
        public static void scrollToElement(IWebElement element) 
        {
            actions = new Actions(driver);
            actions.MoveToElement(element).Build().Perform();

        }

        // Set object for the current page
        public static void SetObject(string pageName)
        {
            if (AllPageBase.pagesStorage.ContainsKey(pageName))
            {
                AllPageBase.pagesStorage.TryGetValue(pageName, out AllPageBase.theObject);
            }
        }

        // Get Web element value of currect page as per the object we set
        public static IWebElement GetWebElement(string elementName)
        {
            // removing White spaces from Page Name
            elementName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(elementName);
            elementName = Regex.Replace(elementName, @"\s+", string.Empty);

            AllPageBase allPages = GetObject();
            Type type = allPages.GetType();
            var property = type.GetProperty(elementName);
            var propertType = property.PropertyType;
            var waitElement = fluentWait.Until(driver => property.GetValue(allPages));
            var propertyValue = property.GetValue(allPages);

            if (propertType == typeof(IWebElement))
            {
                //scrollToElement(propertyValue as IWebElement);
                return propertyValue as IWebElement;
            }

            else
            {
                return null;
            }

        }

        public static IList<IWebElement> GetWebElements(string elementName)
        {
            // removing White spaces from Page Name
            elementName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(elementName);
            elementName = Regex.Replace(elementName, @"\s+", string.Empty);

            AllPageBase allPages = GetObject();
            Type type = allPages.GetType();
            var property = type.GetProperty(elementName);
            var propertType = property.PropertyType;
            var propertyValue = property.GetValue(allPages);

            if (propertType == typeof(IList<IWebElement>))
            {
                //scrollToElement(propertyValue as IWebElement);
                return propertyValue as IList<IWebElement>;
            }

            else
            {
                return null;
            }

        }


        public static IWebElement ExtractWebElementFromElements(IList<IWebElement> elementsList, string text)
        {
            IWebElement returnELement = null;
            bool notifier = false;

            foreach (IWebElement element in elementsList)
            {

                if (element.Text.Equals(text))
                {
                    returnELement = element;
                    notifier = true;
                    break;
                }
            
            }
            if (notifier)
            {
                return returnELement;
            }
            else
            {
                throw new Exception("Element not found");
            }
        
        
        }



        // Get URL variable of currect page as per the object we set
        public static string GetStoredPageUrl()
        {

            AllPageBase allPages = GetObject();
            Type type = allPages.GetType();
            var property = type.GetProperty("url");
            var propertType = property.PropertyType;
            var propertyValue = property.GetValue(allPages);

            if (propertType == typeof(string))
            {
                return propertyValue as string;
            }

            else
            {
                return null;
            }

        }



        // Get object for the current page
        public static AllPageBase GetObject()
        {
            return AllPageBase.theObject;

        }
        //click the web element
        public static void ClickELement(IWebElement webElement)
        {
            IWebElement waitedElement = fluentWait.Until(driver => webElement);

            waitedElement.Click();
        }

        //SendKeys/enter info to web element
        public static void SendInfoToELement(IWebElement webElement, string info)
        {
            IWebElement waitedElement = fluentWait.Until(driver => webElement);
            waitedElement.Clear();
            waitedElement.SendKeys(info);
        }

        //Read element text
        public static string ReadELement(IWebElement webElement)
        {
            IWebElement waitedElement = fluentWait.Until(driver => webElement);
            return waitedElement.Text;
        }
        //Read element text
        public static string ReadELementValue(IWebElement webElement)
        {
            IWebElement waitedElement = fluentWait.Until(driver => webElement);
            return waitedElement.GetAttribute("value");
        }

        //Gets current URL
        public static string GetUrl()
        {
            return driver.Url;
        }

        // Navigate to URL
        public static void NavigateToUrl(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
