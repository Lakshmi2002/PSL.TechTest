using FluentAssertions;
using OpenQA.Selenium.Interactions;

namespace PSL.TechnicalTest.ApplicationUnderTest.Pages;

internal class AmazonHomePage
{
    internal IWebDriver _driver;

    public AmazonHomePage(IWebDriver _driver)
    {
        _driver.Manage().Timeouts().ImplicitWait = System.TimeSpan.FromSeconds(10);
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

    internal IWebElement AddedtoBasket => _driver.FindElement(By.XPath("//span[contains(text(),'Added to Basket')]"));




    // Page Object Actions
    public void NaviageToAmazonHomePage()
    {
        _driver.Navigate().GoToUrl("https://www.amazon.co.uk");
    }
    public void SearchForSportsWatch()
    {
        SearchTextBox.SendKeys("Sports Watch");
        //Actions builder = new Actions(_driver);
        //builder.SendKeys(Keys.Return);
        SearchSubmitButton.Click();
        AcceptCookiesButton.Click();
    }

    public void AddASportsWatchToBasket()
    {
        SportsWatchFromResults.Click();
        AddToCartButton.Click();
        //IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
        //// Scrolling down the page till the element is found		
        //js.ExecuteScript("arguments[0].scrollIntoView();", NoThanksButton);
        //NoThanksButton.Click();
        Thread.Sleep(5000);
    }

    public void SportsWatchIsAddedToBasket()
    {
        CartCount.Text.Should().BeEquivalentTo("1");
        AddedtoBasket.Displayed.Should().BeTrue();
    }

}
