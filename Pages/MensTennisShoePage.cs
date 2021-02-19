using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    class MensTennisShoePage : AllPageBase
    {

        // page URL
        public string url => "https://www.adidas.com.au/men-tennis-shoes";

        public IWebElement Shoe2 => driver.FindElement(By.XPath("//img[@title='Adizero Ubersonic 4 Parley Hard Court Tennis Shoes']"));

        public IWebElement Shoe1Price => driver.FindElement(By.XPath("//span[@title= 'Adizero Ubersonic 4 Tennis Shoes']/parent::div/div/div[contains(@class, 'gl-price-item')]"));

        public IWebElement Shoe2Price => driver.FindElement(By.XPath("//span[@title= 'Adizero Ubersonic 4 Parley Hard Court Tennis Shoes']/parent::div/div/div[contains(@class, 'gl-price-item')]"));

    }
}
