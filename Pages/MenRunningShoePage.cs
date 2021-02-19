using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    class MenRunningShoePage : AllPageBase
    {
        // page URL
        public string url = "https://www.adidas.com.au/men-running-shoes";

        public IWebElement shoe1 => driver.FindElement(By.XPath("//img[@title='Ultraboost 20 All Blacks']"));

    }
}
