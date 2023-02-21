using FinalAssessment2.Drivers;
using FinalAssessment2.Pages.CheckoutProductsPages;
using System;
using TechTalk.SpecFlow;

namespace FinalAssessment2.StepDefinitions
{
    [Binding]
    public class OrderProductsSteps
    {

        private SwagHomePage _homePage;
        private SwagInventoryPage _inventoryPage;
        private SwagCheckoutPage _checkoutPage;
        private SwagCheckoutInformationPage _checkoutInformationPage;
        private SwagCheckoutOverviewPage _checkoutOverviewPage;
        private SwagCheckoutCompletePage _checkoutCompletePage;


        public OrderProductsSteps(DriverHelper helper)
        {
            _homePage = new SwagHomePage(helper.driver);
        }

        [Given(@"User is on SwagLabs Login Page")]
        public void GivenUserIsOnSwagLabsLoginPage()
        {
            _homePage.NavigateToHomePage();           
        }

        [Given(@"User verifies that the site header logo is displayed")]
        public void GivenUserVerifiesThatTheSiteHeaderLogoIsDisplayed()
        {
            _homePage.Verify();

        }

        [When(@"User populates login fields with ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserPopulatesLoginFieldsWithAnd(string userName, string password)
        {
            _homePage.userName = userName;
            _homePage.password = password;
            _homePage.PopulateLoginFields();
        }

        [When(@"User clicks on the login button on the Login Page")]
        public void WhenUserClicksOnTheLoginButtonOnTheLoginPage()
        {
            _inventoryPage = _homePage.ClickAddCustomerLink();            
        }

        [Then(@"User is navigated to the Inventory Page")]
        public void ThenUserIsNavigatedToTheInventoryPage()
        {
            _inventoryPage.VerifyPage();
        }

        [Then(@"User verifies if there are products in the Inventory Page")]
        public void ThenUserVerifiesIfThereAreProductsInTheInventoryPage()
        {
            _inventoryPage.VerifyProducts();
        }

        [When(@"User adds products to the Cart in the Inventory Page")]
        public void WhenUserAddsProductsToTheCartInTheInventoryPage()
        {
            _inventoryPage.AddBackpackAndBikeLightToCart();
        }


        [When(@"User clicks on the Shopping Cart icon in the Inventory Page")]
        public void WhenUserClicksOnTheShoppingCartIconInTheInventoryPage()
        {
            _checkoutPage = _inventoryPage.ClickCartIcon();
        }

     
        [Then(@"User is navigated to the Checkout Page\.")]
        public void ThenUserIsNavigatedToTheCheckoutPage_()
        {
            _checkoutPage.VerifyPage();
        }

        [Then(@"User verifies the product name and price in the Checkout Page")]
        public void ThenUserVerifiesTheProductNameAndPriceInTheCheckoutPage()
        {
            _checkoutPage.VerifyProductAndPriceValues();
        }

        [When(@"User clicks the Checkout button in the checkout page")]
        public void WhenUserClicksTheCheckoutButtonInTheCheckoutPage()
        {
            _checkoutInformationPage = _checkoutPage.Checkout();

        }

        [Then(@"User is navigated to the Checkout information page")]
        public void ThenUserIsNavigatedToTheCheckoutInformationPage()
        {
            _checkoutInformationPage.VerifyPage();
        }

        [Then(@"User verifies the Checkout information page")]
        public void ThenUserVerifiesTheCheckoutInformationPage()
        {
            _checkoutInformationPage.VerifyForm();
        }

  

        [When(@"User populates the information page in the Checkout Information Page with ""([^""]*)"", ""([^""]*)""  and ""([^""]*)""")]
        public void WhenUserPopulatesTheInformationPageInTheCheckoutInformationPageWithAnd(string firstName, string lastName, string zipCode)
        {
            _checkoutInformationPage.firstName= firstName; ;
            _checkoutInformationPage.lastName= lastName;
            _checkoutInformationPage.zipCode=   zipCode;
            _checkoutInformationPage.PopulateFields();
        }


        [When(@"User clicks the continue button in the Checkout Information Page")]
        public void WhenUserClicksTheContinueButtonInTheCheckoutInformationPage()
        {
            _checkoutOverviewPage = _checkoutInformationPage.ContinueCheckout();
        }

        [Then(@"User is navigated to the Checkout Overview Page")]
        public void ThenUserIsNavigatedToTheCheckoutOverviewPage()
        {
            _checkoutOverviewPage.VerifyPage();
        }

        [Then(@"User verifies the payment information, shipping information, item total, tax and total values int the Overview Page")]
        public void ThenUserVerifiesThePaymentInformationShippingInformationItemTotalTaxAndTotalValuesIntTheOverviewPage()
        {
            _checkoutOverviewPage.VerifyPaymentInformation();
            _checkoutOverviewPage.VerifyShippingInformation();
            _checkoutOverviewPage.VerifyItemTotal();
            _checkoutOverviewPage.VerifyTax();
            _checkoutOverviewPage.VerifyTotalValues();

        }

        [When(@"User clicks Finish button in the Checkout Overview Page")]
        public void WhenUserClicksFinishButtonInTheCheckoutOverviewPage()
        {
            _checkoutCompletePage = _checkoutOverviewPage.ClickFinishButton();
        }

        [Then(@"User is navigated to the Checkout Complete Page")]
        public void ThenUserIsNavigatedToTheCheckoutCompletePage()
        {
            _checkoutCompletePage.VerifyPage();
        }

        [Then(@"User verifies the Thank you header and description in the Checkout Overview Page")]
        public void ThenUserVerifiesTheThankYouHeaderAndDescriptionInTheCheckoutOverviewPage()
        {
            _checkoutCompletePage.VerifyHeader();
            _checkoutCompletePage.VerifyDescription();

        }

        [When(@"User Clicks Back Home button in the Checkout Overview Page")]
        public void WhenUserClicksBackHomeButtonInTheCheckoutOverviewPage()
        {
            _inventoryPage = _checkoutCompletePage.ClickBackHome();

        }

        [Then(@"User is navigated again to the Inventory Page")]
        public void ThenUserIsNavigatedAgainToTheInventoryPage()
        {
            _inventoryPage.VerifyPage();
        }

        [When(@"User clicks the menu button in the Inventory Page")]
        public void WhenUserClicksTheMenuButtonInTheInventoryPage()
        {
            _inventoryPage.ClickMenu();
        }

        [When(@"User clicks on the logout button in the menu")]
        public void WhenUserClicksOnTheLogoutButtonInTheMenu()
        {
            _inventoryPage.ClickLogout();

        }



    }
}
