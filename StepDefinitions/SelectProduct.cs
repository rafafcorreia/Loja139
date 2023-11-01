using AngleSharp.Common;
using AngleSharp.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace StepDefinitions
{
    [Binding]
    public class SelectProduct
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        public SelectProduct(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario, Scope(Tag = "simples")]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig()); // Configuração do WebDriverManager
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
            driver.Manage().Window.Maximize();
        }
        [AfterScenario, Scope(Tag = "simples")]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"I access SauceDemo store")]
        public void GivenIAccessSauceDemoStore()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        [When(@"I filled a user ""(.*)"" and password ""(.*)""")]
        public void WhenIFilledAUserAndPassword(string username, string password)
        {
            driver.FindElement(By.Id("user-name")).SendKeys(username);
            driver.FindElement(By.Name("password")).SendKeys(password);
        }

        [When(@"I click in Login")]
        public void WhenIClickInLogin()
        {
            driver.FindElement(By.CssSelector("input.submit-button.btn_action")).Click();
        }

        [When(@"I click in product ""(.*)""")]
        public void WhenIClickInProduct(string productName)
        {
            driver.FindElement(By.CssSelector($"img[alt=\"{productName}\"]")).Click();
        }

        [When(@"I click in Add to Cart")]
        public void WhenIClickInAddToCart()
        {
            driver.FindElement(By.Id("add-to-cart-sauce-labs-backpack")).Click();
            Assert.That(driver.FindElement(By.CssSelector(".shopping_cart_badge")).Text, Is.EqualTo("1"));
        }

        [When(@"I click in Cart icon")]
        public void WhenIClickInCartIcon()
        {
            driver.FindElement(By.ClassName("shopping_cart_link")).Click();
        }

        [Then(@"show page's title ""(.*)""")]
        public void ThenShowPagesTitle(string pageTitle)
        {
            Assert.That(driver.FindElement(By.CssSelector("span.title")).Text, Is.EqualTo(pageTitle));
        }

        [Then(@"show cart's link")]
        public void ThenShowCartsLink()
        {
            Assert.True(driver.FindElement(By.CssSelector("a.shopping_cart_link")).Displayed);
        }

        [Then(@"I verify the product title ""(.*)""")]
        public void ThenIVerifyTheProductTitle(string productTitle)
        {
            Assert.That(driver.FindElement(By.CssSelector(".inventory_details_name.large_size")).Text, Is.EqualTo(productTitle));
        }

        [Then(@"I verify the product price ""(.*)""")]
        public void ThenIVerifyTheProductPrice(string productPrice)
        {
            Assert.That(driver.FindElement(By.CssSelector(".inventory_details_price")).Text, Is.EqualTo(productPrice));
        }

        [Then(@"I verify the page's title ""(.*)""")]
        public void ThenIVerifyThePagesTitle(string pageTitle)
        {
            Assert.That(driver.FindElement(By.CssSelector(".title")).Text, Is.EqualTo(pageTitle));
        }

        [Then(@"I verify the product title at the cart ""(.*)""")]
        public void ThenIVerifyTheProductTitleAtTheCart(string productTitle)
        {
            Assert.That(driver.FindElement(By.CssSelector(".inventory_item_name")).Text, Is.EqualTo(productTitle));
        }

        [Then(@"I verify the product price at the cart ""(.*)""")]
        public void ThenIVerifyTheProductPriceAtTheCart(string productPrice)
        {
            Assert.That(driver.FindElement(By.CssSelector(".inventory_item_price")).Text, Is.EqualTo(productPrice));
            // Thread.Sleep(3000);
        }

        [Then(@"I verify the quantity is ""(.*)""")]
        public void ThenIVerifyTheQuantityIs(string quantity)
        {
            Assert.That(driver.FindElement(By.CssSelector(".cart_quantity")).Text, Is.EqualTo(quantity));
        }
    }
}