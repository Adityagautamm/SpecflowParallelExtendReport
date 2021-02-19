using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using SpecFlowProject1.FrameworkBase;
using SpecFlowProject1.Helper;
using SpecFlowProject1.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace SpecFlowProject1.Hooks
{
    [Binding]
    class BaseHooks
    {
        public static ExtentTest featureName;
        public static ExtentTest scenarioName;
        public static ExtentReports extent;
        private readonly ScenarioContext _scenarioContext;
        public BaseHooks(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
        }

        [BeforeTestRun]
        public static void allPageSetUp()
        {
            AllPageBase.AddAllPages();
            
            //Setting up Extend report
            var htmlReporter = new ExtentHtmlReporter("C:\\Users\\Aditya Gautam\\source\\repos\\SpecflowProjectV2\\ExtentReport.html");
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;

            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void afterTestHook()
        {
            extent.Flush();
        }

        [BeforeFeature]
        public static void beforeFeatureHook(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterStep]
        public void afterStepHook()
        {
            var stepType = _scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();


            if (_scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    scenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text);
                }
                else if (stepType == "When")
                {
                    scenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text);
                }
                else if (stepType == "Then")
                {
                    scenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text);
                }
                else if (stepType == "And")
                {
                    scenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text);
                }
            }

          else if (_scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                {
                    scenarioName.CreateNode<Given>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                }
                else if (stepType == "When")
                {
                    scenarioName.CreateNode<When>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.InnerException);
                }
                else if (stepType == "Then")
                {
                    scenarioName.CreateNode<Then>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
                else if (stepType == "And")
                {
                    scenarioName.CreateNode<And>(_scenarioContext.StepContext.StepInfo.Text).Fail(_scenarioContext.TestError.Message);
                }
            }



        }



        [BeforeScenario]
        public void Initialisation()
        {
            FrameBase.Initialization();         
            scenarioName = featureName.CreateNode<Scenario>(_scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void dropContextSTorage() 
        {
          //  ScenarioContextStorage.resetContext();
            FrameBase.TearDown();

        }
    }
}
