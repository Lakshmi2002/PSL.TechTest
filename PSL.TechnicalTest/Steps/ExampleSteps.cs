using PSL.TechnicalTest.ApplicationUnderTest.Pages;

namespace PSL.TechnicalTest.Steps
{
    [Binding]
    internal class ExampleSteps
    {

        private readonly IWebDriver _driver;
        private AmazonHomePage _amazonHomePage => new AmazonHomePage(_driver);

        public ExampleSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [Given(@"I am navigated to amazon homepage")]
        public void GivenIAmNavigatedToAmazonHomepage()
        {
            _amazonHomePage.NaviageToAmazonHomePage();
        }

        [Given(@"I search for a sports watch")]
        public void GivenISearchForASportsWatch()
        {
            _amazonHomePage.SearchForSportsWatch();
        }

        [Given(@"sports watch is added to basket")]
        public void GivenSportsWatchIsAddedToBasket()
        {
            GivenIAmNavigatedToAmazonHomepage();
            GivenISearchForASportsWatch();
            WhenIAddTheItemToTheBasket();
            ThenSportsWatchIsAddedToBasket();
        }

        [Given(@"I am on the cart view page")]
        public void GivenIAmOnTheCartViewPage()
        {
            _amazonHomePage.ClickOnBasketIcon();
        }

        [When(@"I click on the delete link on the shopping basket")]
        public void WhenIClickOnTheDeleteLinkOnTheShoppingBasket()
        {
            _amazonHomePage.IClickOnTheDeleteLinkOnTheShoppingCart();
        }

        [When(@"I click on the sports watch in the shopping basket")]
        public void WhenIClickOnTheSportsWatchInTheShoppingBasket()
        {
            _amazonHomePage.ClickOnTheSportsWatchInTheShoppingCart();
        }

        [When(@"I add the item to the basket")]
        public void WhenIAddTheItemToTheBasket()
        {
            _amazonHomePage.AddASportsWatchToBasket();
        }

        [Then(@"sports watch is added to basket")]
        public void ThenSportsWatchIsAddedToBasket()
        {
            _amazonHomePage.SportsWatchIsAddedToBasket();
        }

        [Then(@"shopping basket quantity is zero")]
        public void ThenShoppingBasketQuantityIsZero()
        {
            _amazonHomePage.ShoppingBasketQuantityIsZero();
        }

        [Then(@"page redirects to the sports watch product detail page")]
        public void ThenPageRedirectsToTheSportsWatchProductDetailPage()
        {
            _amazonHomePage.PageRedirectsToTheSportsWatchProductDetailPage();
        }

    }

}