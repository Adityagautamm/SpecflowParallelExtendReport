using OpenQA.Selenium;
using SpecFlowProject1.FrameworkBase;
using SpecFlowProjectV2.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowProject1.Pages
{
    class AllPageBase : FrameBase
    {
        // object to set for currect page
        public static AllPageBase theObject = null;

        public static IWebElement PopupClose => driver.FindElement(By.XPath("abc"));

        public static Dictionary<string, AllPageBase> pagesStorage = new Dictionary<string, AllPageBase>();

        public static void AddAllPages()
        {
            pagesStorage.Add("Mens Tennis Shoe", new MensTennisShoePage());
            pagesStorage.Add("Mens Running Shoe", new MenRunningShoePage());
            pagesStorage.Add("Shoe1", new Shoe1Page());
            pagesStorage.Add("Shoe2", new Shoe2Page());
        }

    }
}
