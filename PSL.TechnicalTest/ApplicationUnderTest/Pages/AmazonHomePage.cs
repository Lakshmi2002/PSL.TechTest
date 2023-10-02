using FluentAssertions;
using OpenQA.Selenium.Support.UI;
using PSL.TechnicalTest.Helpers;
using SeleniumExtras.WaitHelpers;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages;

internal class AmazonHomePage
{
    internal IWebDriver _driver;

    public AmazonHomePage(IWebDriver _driver)
    {
        this._driver = _driver;
    }

    // Page Object Controls

    internal IWebElement SearchTextBox => _driver.FindElement(By.Id("twotabsearchtextbox"));
    internal IWebElement SearchSubmitButton => _driver.FindElement(By.XPath("//input[@id='nav-search-submit-button']"));

    internal IWebElement SportsWatchFromResults => _driver.FindElement(By.XPath("//div[3]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[1]//div[2]//div[1]//div[1]//div[1]//h2[1]//a[1]//span[1]"));
    internal IWebElement AddToCartButton => _driver.FindElement(By.Id("add-to-cart-button"));

    internal IWebElement NoThanksButton => _driver.FindElement(By.XPath("//input[@aria-labelledby='attachSiNoCoverage-announce']"));

    internal IWebElement AcceptCookiesButton => _driver.FindElement(By.Id("sp-cc-accept"));

    internal IWebElement CartCount => _driver.FindElement(By.Id("nav-cart-count"));

    internal IWebElement AddedtoBasketLabel => _driver.FindElement(By.XPath("//span[contains(text(),'Added to Basket')]"));

    internal IWebElement ShoppingBasketImage => _driver.FindElement(By.XPath("//img[contains(@class, 'sc-product-image')]"));

    internal IWebElement LandingPageImage => _driver.FindElement(By.XPath("(//span[@data-action='main-image-click'])[1]"));

    internal IWebElement Basket => _driver.FindElement(By.XPath("//div[@id='nav-cart-text-container']//span[2]"));

    internal IWebElement ShoppingBasketDeleteLink => _driver.FindElement(By.XPath("(//input[contains(@value, 'Delete')])[1]"));
    

    // Page Object Actions

    public void ShoppingBasketQuantityIsZero()
    {
        CartCount.Text.Should().BeEquivalentTo("0");
    }

    public void ClickOnBasketIcon()
    {
        Basket.Click();
    }
    public void NaviageToAmazonHomePage()
    {
        _driver.Navigate().GoToUrl("https://www.amazon.co.uk");
    }
    public void SearchForSportsWatch()
    {
        SearchTextBox.SendKeys("Sports Watch");
        SearchSubmitButton.Click();
        AcceptCookiesButton.Click();
    }

    public void IClickOnTheDeleteLinkOnTheShoppingCart()
    {
        ShoppingBasketDeleteLink.Click();
    }

    public void AddASportsWatchToBasket()
    {
        SportsWatchFromResults.Click();
        AddToCartButton.Click();
        try
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            wait.Until(ExpectedConditions.ElementExists(By.XPath("//input[@aria-labelledby='attachSiNoCoverage-announce']")));
            NoThanksButton.Click();
        }
        catch (NoSuchElementException)
        {
            //// ignore 
        }
       
    }

    public void AssertWithRetry(Action assertFunction)
    {
        Retry.RetryPolicy.Execute(assertFunction);
    }

    public void SportsWatchIsAddedToBasket()
    {
        AssertWithRetry(
            () =>
            {
                CartCount.Text.Should().BeEquivalentTo("1");
            });
       
        AddedtoBasketLabel.Displayed.Should().BeTrue();
    }

    public void ClickOnTheSportsWatchInTheShoppingCart()
    {
        ShoppingBasketImage.Click();
    }
    
    public void PageRedirectsToTheSportsWatchProductDetailPage()
    {
        //LandingPageImage.Displayed.Should().BeTrue();
        AddToCartButton.Displayed.Should().BeTrue();
    }

}
