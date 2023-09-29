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




    }

}