using FinalAssessment2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalAssessment2.Pages.CheckoutProductsPages
{
    public class SwagCheckoutPage : BasePage
    {
        public SwagCheckoutPage(IWebDriver driver)
        {
            this.driver = driver; 
        }

        private By cartTitle = By.XPath("*//span[text()='Your Cart']");
        private By btnCheckout = By.Id("checkout");
        private By lblSauceLabsBackpack = By.XPath("*//div[text()='Sauce Labs Backpack' and @class='inventory_item_name']");
        private By lblSauceLabsBackpackPrice = By.XPath("*//div[text()='29.99' and @class='inventory_item_price']");
        private By lblSauceLabsBikeLight = By.XPath("*//div[text()='Sauce Labs Bike Light' and @class='inventory_item_name']");
        private By lblSauceLabsBikeLightPrice = By.XPath("*//div[text()='9.99' and @class='inventory_item_price']");


        public SwagCheckoutPage VerifyPage()
        {
            Assert.IsTrue(FindElement(cartTitle).Displayed);
            return this;
        }

        public SwagCheckoutPage VerifyProductAndPriceValues()
        {
            Assert.IsTrue(FindElement(lblSauceLabsBackpack).Displayed);
            Assert.IsTrue(FindElement(lblSauceLabsBackpackPrice).Displayed);
            Console.WriteLine("Product Sauce Labs Backpack with the price of $29.99 is verified");
            Assert.IsTrue(FindElement(lblSauceLabsBikeLight).Displayed);
            Assert.IsTrue(FindElement(lblSauceLabsBikeLightPrice).Displayed);
            Console.WriteLine("Product Sauce Labs Bike Light with the price of $9.99 is verified");
            return this;
        }

        public SwagCheckoutInformationPage Checkout()
        {
            Click(btnCheckout);
            return new SwagCheckoutInformationPage(driver);
        }


    }
}
