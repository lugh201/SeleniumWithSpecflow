using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalAssessment2.Drivers
{
    public class DriverHelper
    {
        public IWebDriver driver;

        public DriverHelper()
        {
            driver = new ChromeDriver();
        }
    }
}
