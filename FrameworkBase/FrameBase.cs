using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SpecFlowProject1.FrameworkBase
{
    class FrameBase
	{
		public static IWebDriver driver;
		public static DefaultWait<IWebDriver> fluentWait;

		public static void Initialization()
		{
			// setting driver statically
			driver = new ChromeDriver(@"C:\Users\Aditya Gautam\Desktop\curious fella\Automation\webdriver\chrome");

			 fluentWait = new DefaultWait<IWebDriver>(driver);
			fluentWait.Timeout = TimeSpan.FromSeconds(5);
			fluentWait.PollingInterval = TimeSpan.FromMilliseconds(250);
			/* Ignore the exception - NoSuchElementException that indicates that the element is not present */
			fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
			fluentWait.Message = "Element to be searched not found";

			// maximizing the window
			driver.Manage().Window.Maximize();
			
			//Implicit wait
			driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);


			//Page Load 
			driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);



		}


		public static void TearDown()
		{
			try
			{
				Thread.Sleep(2000);
			}
			catch (Exception e)
			{
				// TODO Auto-generated catch block

			}
			driver.Quit();
		}



	}

}

