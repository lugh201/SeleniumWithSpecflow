using FinalAssessment2.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;


namespace FinalAssessment2.Pages.CheckoutProductsPages
{
    public class SwagCheckoutInformationPage : BasePage
    {
        public SwagCheckoutInformationPage(IWebDriver driver)
        {
            this.driver = driver;
        }


        private By checkoutInformationTitle = By.XPath("*//span[text()='Checkout: Your Information']");
        private By tBoxFirstName = By.Id("first-name");
        private By tBoxLastName = By.Id("last-name");
        private By tBoxZipCode = By.Id("postal-code");
        private By btnContinue = By.Id("continue");

        public string firstName { get; set; }
        public string lastName { get; set; }
        public string zipCode { get; set; }






        public SwagCheckoutInformationPage VerifyPage()
        {
            Assert.IsTrue(FindElement(checkoutInformationTitle).Displayed);
            Console.WriteLine("Checkout: Your Information Page is displayed");
            return this;
        }

        public SwagCheckoutInformationPage VerifyForm()
        {
            Assert.IsTrue(FindElement(tBoxFirstName).Displayed);       
            return this;
        }



        public SwagCheckoutInformationPage PopulateFields()
        {
            EnterText(tBoxFirstName, firstName);
            EnterText(tBoxLastName, lastName);
            EnterText(tBoxZipCode, zipCode);

            return this;
        }
        public SwagCheckoutOverviewPage ContinueCheckout()
        {
            Click(btnContinue);
            return new SwagCheckoutOverviewPage(driver);
        }

    }

}