using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    class Shoe1Page: AllPageBase
    {
        // page URL
        public string url => "https://www.adidas.com.au/adizero-ubersonic-4-tennis-shoes/G55454.html";

        public IWebElement Price => driver.FindElement(By.XPath("(//div[@class='gl-price-item notranslate'])[2]"));

    }
}
