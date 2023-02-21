using FinalAssessment2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace FinalAssessment2.Pages.CheckoutProductsPages
{
    public class SwagCheckoutCompletePage : BasePage
    {
        public SwagCheckoutCompletePage(IWebDriver driver)
        {
            this.driver = driver;
        }


        private By checkoutInformationTitle = By.XPath("*//span[text()='Checkout: Complete!']");
        private By lblHeader = By.ClassName("complete-header");
        private By lblDescription = By.ClassName("complete-text");
        private By btnBackHome = By.Id("back-to-products");


        public SwagCheckoutCompletePage VerifyPage()
        {
            Assert.IsTrue(FindElement(checkoutInformationTitle).Displayed);
            Console.WriteLine("“Checkout: Complete Page is displayed");
            return this;
        }

        public SwagCheckoutCompletePage VerifyHeader()
        {
            Assert.IsTrue(FindElement(lblHeader).Displayed);
            Console.WriteLine("Thank you Header is verified");
            return this;
        }


        public SwagCheckoutCompletePage VerifyDescription()
        {
            Assert.IsTrue(FindElement(lblDescription).Displayed);
            Console.WriteLine("Description text is verified");
            return this;
        }
     
        public SwagInventoryPage ClickBackHome()
        {
            Click(btnBackHome);
            return new SwagInventoryPage(driver);
        }

    }

}