using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports;
using FinalAssessment2.Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace FinalAssessment2.Utilities
{
    [Binding]
    public sealed class Hooks
    {
        private DriverHelper _helper;
        public static ExtentReports extent;
        public static ExtentHtmlReporter reporter;
        public static ExtentTest scenario;
        public static ExtentTest featureName;

        public Hooks(DriverHelper helper)
        {
            _helper = helper;
        }

        [BeforeTestRun]
        public static void SetUpReport()
        {
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net6.0", "") + @"Report\";

            if (extent == null)
            {
                extent = new ExtentReports();
                reporter = new ExtentHtmlReporter(path);
                reporter.Config.DocumentTitle = "Automation Testing Report";
                reporter.Config.ReportName = "Extent Report" + DateTime.Now;
                reporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Standard;
                extent.AttachReporter(reporter);
                extent.AddSystemInfo("Machine", Environment.MachineName);
                extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
            }
        }

        [BeforeFeature]
        public static void CreateTest(FeatureContext featureContext)
        {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenarioWithTag(ScenarioContext scenarioContext)
        {
            scenario = featureName.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
            _helper.driver.Manage().Window.Maximize();
            _helper.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [AfterStep]
        public void InsertReportingSteps(ScenarioContext scenarioContext)
        {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            string path = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net6.0", "") + @"Report\Screenshots\";
            string timeStamp = DateTime.Now.ToString("G").Replace("/", "").Replace(":", "").Replace(" ", "");
            string finalPath = path + "Image_" + timeStamp + ".png";

            /// <summary>
            /// Capture screenshot
            /// </summary>
            ITakesScreenshot ts = (ITakesScreenshot)_helper.driver;
            Screenshot screenshot = ts.GetScreenshot();
            screenshot.SaveAsFile(finalPath, ScreenshotImageFormat.Png);


            /// <summary>
            /// Generate passed test nodes for each Gherkin keyword for scenario run
            /// </summary>
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(finalPath);
                else if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(finalPath);
                else if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(finalPath);
                else if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).AddScreenCaptureFromPath(finalPath);
            }

            /// <summary>
            /// Generate failed test nodes for each Gherkin keyword for scenario run
            /// </summary>
            if (scenarioContext.TestError != null)
            {
                if (stepType == "Given")
                    scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message)
                        .AddScreenCaptureFromBase64String(finalPath);
                if (stepType == "When")
                    scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message)
                        .AddScreenCaptureFromBase64String(finalPath);
                if (stepType == "Then")
                    scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message)
                        .AddScreenCaptureFromBase64String(finalPath);
                if (stepType == "And")
                    scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text).Fail(scenarioContext.TestError.Message)
                        .AddScreenCaptureFromBase64String(finalPath);
            }
            Thread.Sleep(300);
        }

        [AfterTestRun]
        public static void TearDownReport()
        {
            /// <summary>
            /// Flush or close the report
            /// </summary>
            extent.Flush();

            /// <summary>
            /// Code to rename the index.html report to Automation Testing Report
            /// </summary>
            string timeStamp = DateTime.Now.ToString("G").Replace("/", "-").Replace(":", "_").Replace(" ", "_");
            string oldFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net6.0", "") + @"Report\index.html";
            string newFilePath = AppDomain.CurrentDomain.BaseDirectory.Replace(@"\bin\Debug\net6.0", "") + @"Report\Automation Testing Report_" + timeStamp + ".html";
            File.Move(oldFilePath, newFilePath);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            _helper.driver.Quit();
        }
    }
}