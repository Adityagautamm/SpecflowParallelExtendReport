using OpenQA.Selenium;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProjectV2.Pages
{
    class Shoe2Page : AllPageBase
    {
        // page URL
        public string url => "https://www.adidas.com.au/adizero-ubersonic-4-parley-hard-court-tennis-shoes/FX1479.html";

        public IWebElement Price => driver.FindElement(By.XPath("(//div[@class='gl-price-item notranslate'])[2]"));

    }
}
