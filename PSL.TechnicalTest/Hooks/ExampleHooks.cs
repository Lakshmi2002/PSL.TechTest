﻿using BoDi;
using OpenQA.Selenium.Chrome;


namespace PSL.TechnicalTest.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeScenario(Order = 0)]
        public void BeforeScenario()
        {
            GetDriver(false);
        }

        [AfterScenario]
        public void QuitWebDriver()
        {
            IWebDriver webDriver = _objectContainer.Resolve<IWebDriver>();
            if (webDriver != null)
            {
                webDriver.Quit();
            }
        }

        
        public IWebDriver GetDriver(bool headless)
        {
            if (_driver == null)
            {
                switch ("Chrome")
                {
                    case "Chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        if (headless)
                        {
                            chromeOptions.AddArgument("--window-size=1920,1080");
                            chromeOptions.AddArgument("--start-maximized");
                            chromeOptions.AddArgument("--headless");
                        }

                        _driver = new ChromeDriver(Environment.CurrentDirectory, chromeOptions);
                        break;
                }

                try
                {
                    _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
                    _driver.Manage().Cookies.DeleteAllCookies();
                    _driver.Manage().Window.Maximize();
                    _objectContainer.RegisterInstanceAs(_driver);
                }
                catch (NullReferenceException e)
                {
                    Console.WriteLine(e.Message + " Driver failed to initialize");
                }
            }

            return _driver;
        }
    }
}
