using NUnit.Framework;
using OpenQA.Selenium;

namespace FinalAssessment2.Pages.CheckoutProductsPages
{
    public class SwagInventoryPage : BasePage
    {

        public SwagInventoryPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private By btnCart = By.Id("shopping_cart_container");
        private By addSauceLabsBackpack = By.Id("add-to-cart-sauce-labs-backpack");
        private By addSauceLabsBikeLight = By.Id("add-to-cart-sauce-labs-bike-light");
        private By inventoryProducts = By.ClassName("inventory_item");
        private By productTitle = By.XPath("*//span[text()='Products']");

        private By btnMenu = By.Id("react-burger-menu-btn"); 
        private By linkLogout = By.Id("logout_sidebar_link");



        public SwagInventoryPage VerifyProducts()
        {
            Assert.IsTrue(FindElement(inventoryProducts).Displayed);
            return this;
        }

        public SwagInventoryPage VerifyPage()
        {
            Assert.IsTrue(FindElement(productTitle).Displayed);
            return this;
        }

        public SwagInventoryPage AddBackpackAndBikeLightToCart()
        {
            Click(addSauceLabsBikeLight);
            Click(addSauceLabsBackpack);
            Console.WriteLine("Successfully Added 2 Products");

            return this;
        }

        public SwagCheckoutPage ClickCartIcon()
        {
            Click(btnCart);
            return new SwagCheckoutPage(driver);
        }

        public SwagInventoryPage ClickMenu()
        {
            Click(btnMenu);
            return this;
        }

        public SwagHomePage ClickLogout()
        {
            Click(linkLogout);
            Console.WriteLine("Logout Successful");
            return new SwagHomePage(driver);
        }
    }
}