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
    public class SwagCheckoutOverviewPage:BasePage
    {
        public SwagCheckoutOverviewPage(IWebDriver driver)
        {
            this.driver = driver; 
        }

        private By checkoutInformationTitle = By.XPath("*//span[text()='Checkout: Overview']");
        private By paymentInformation = By.XPath("*//div[@class='summary_value_label' and text()='SauceCard #31337']");
        private By shippingInformation = By.XPath("*//div[@class='summary_value_label' and text()='FREE PONY EXPRESS DELIVERY!']");
        private By itemTotal = By.XPath("*//div[@class='summary_subtotal_label' and text()='39.98']");
        private By tax = By.XPath("*//div[@class='summary_tax_label' and text()='3.20']");
        private By totalValues = By.XPath("*//div[@class='summary_total_label' and text()='43.18']");
        private By btnFinish = By.Id("finish");


        public SwagCheckoutOverviewPage VerifyPage()
        {
            Assert.IsTrue(FindElement(checkoutInformationTitle).Displayed);
            Console.WriteLine("Checkout: Overview Page is displayed");

            return this;
        }

        public SwagCheckoutOverviewPage VerifyPaymentInformation()
        {
            Assert.IsTrue(FindElement(paymentInformation).Displayed);
            Console.WriteLine("Payment Information - SauceCard #31337 verified ");
            return this;
        }
        public SwagCheckoutOverviewPage VerifyShippingInformation()
        {
            Assert.IsTrue(FindElement(shippingInformation).Displayed);
            Console.WriteLine("Shipping Information - FREE PONY EXPRESS DELIVERY! verified ");

            return this;
        }
        public SwagCheckoutOverviewPage VerifyItemTotal()
        {
            Assert.IsTrue(FindElement(itemTotal).Displayed);
            Console.WriteLine("Item Total - $39.98 verified ");
            return this;
        }
        public SwagCheckoutOverviewPage VerifyTax()
        {
            Assert.IsTrue(FindElement(tax).Displayed);
            Console.WriteLine("Tax - $3.20 verified ");

            return this;
        }

        public SwagCheckoutOverviewPage VerifyTotalValues()
        {
            Assert.IsTrue(FindElement(totalValues).Displayed);
            Console.WriteLine("Total - $43.18 verified ");

            return this;
        }

        public SwagCheckoutCompletePage ClickFinishButton()
        {
            Click(btnFinish);
            return new SwagCheckoutCompletePage(driver);
        }




    }
}
