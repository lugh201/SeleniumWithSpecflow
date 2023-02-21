using NUnit.Framework;
using OpenQA.Selenium;

namespace FinalAssessment2.Pages.CheckoutProductsPages
{
    public class SwagHomePage : BasePage
    {

        private string pageUrl = "https://www.saucedemo.com/";
        public SwagHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By btnLogin = By.Id("login-button");
        private By imgLogo = By.ClassName("login_logo");
        private By txtUserName = By.Id("user-name");
        private By txtPassword = By.Id("password");

        public string userName { get; set; }
        public string password { get; set; }

        public SwagHomePage NavigateToHomePage()
        {
            NavigateToUrl(pageUrl);
            return this;
        }

        public SwagHomePage Verify()
        {
            Assert.IsTrue(FindElement(imgLogo).Displayed);
            return this;
        }

        public SwagHomePage PopulateLoginFields()
        {
            EnterText(txtUserName, userName);
            EnterText(txtPassword, password);
            return this;
        }

        public SwagInventoryPage ClickAddCustomerLink()
        {
            Click(btnLogin);
            Console.WriteLine("Sucessful Login");
            return new SwagInventoryPage(driver);
        }
    }
}