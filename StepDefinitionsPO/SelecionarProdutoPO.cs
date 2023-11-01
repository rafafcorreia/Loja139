
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Pages;
using TechTalk.SpecFlow;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace StepDefinitionsPO
{
    [Binding]
    public class SelectProductPO
    {
        private readonly ScenarioContext _scenarioContext;
        private IWebDriver driver;

        private HomePage homePage;
        private InventoryPage inventoryPage;
        private InventoryItemPage inventoryItemPage;
        private CartPage cartPage;

        public SelectProductPO(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario, Scope(Tag = "PO")]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new ChromeConfig()); // Configuração do WebDriverManager
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(5000);
            driver.Manage().Window.Maximize();
            
        }
        [AfterScenario, Scope(Tag = "PO")]
        public void TearDown()
        {
            driver.Quit();
        }

        [Given(@"I access SauceDemo store PO")]
        public void GivenIAccessSauceDemoStorePO()
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            homePage = new HomePage(driver);
        }

        [When(@"I filled a user ""(.*)"" and password ""(.*)"" PO")]
        public void WhenIFilledAUserAndPasswordPO(string username, string password)
        {
            homePage.Logar(username, password);
        }

        [When(@"I click in Login PO")]
        public void WhenIClickInLoginPO()
        {
            homePage.CliclarBotaoLogin();
            inventoryPage = new InventoryPage(driver);
        }

        [When(@"I click in product ""(.*)"" PO")]
        public void WhenIClickInProductPO(string productName)
        {
            inventoryPage.CliclarNoProduto(productName);
            inventoryItemPage = new InventoryItemPage(driver);
        }

        [When(@"I click in Add to Cart PO")]
        public void WhenIClickInAddToCartPO()
        {
            inventoryItemPage.AdicionarNoCarrinho();
            Assert.That(inventoryItemPage.LerIconeCarrinhoNumero(), Is.EqualTo("1"));
        }

        [When(@"I click in Cart icon PO")]
        public void WhenIClickInCartIconPO()
        {
            inventoryItemPage.ClicarIconeCarrinho();
            cartPage = new CartPage(driver);
        }

        [Then(@"I verify the page's title ""(.*)"" PO")]
        public void ThenIVerifyThePagesTitlePO(string pageTitle)
        {
            Assert.That(cartPage.lerCabecalhoDaPagina(), Is.EqualTo(pageTitle));
        }

        [Then(@"show cart's link PO")]
        public void ThenShowCartsLinkPO()
        {
            Assert.True(homePage.IconeCarrinhoEstaPresente());
        }

        [Then(@"I verify the product title ""(.*)"" PO")]
        public void ThenIVerifyTheProductTitlePO(string productTitle)
        {
            Assert.That(inventoryItemPage.LerTituloProduto(), Is.EqualTo(productTitle));
        }

        [Then(@"I verify the product price ""(.*)"" PO")]
        public void ThenIVerifyTheProductPricePO(string productPrice)
        {
            Assert.That(inventoryItemPage.LerPrecoProduto(), Is.EqualTo(productPrice));
        }

        [Then(@"I verify the home page's title ""(.*)"" PO")]
        public void ThenIVerifyTheHomePagesTitlePO(string pageTitle)
        {
            Assert.That(homePage.lerCabecalhoDaPagina(), Is.EqualTo(pageTitle));
        }

        [Then(@"I verify the product title ""(.*)"" in cart PO")]
        public void ThenIVerifyTheProductTitleInCartPO(string productTitle)
        {
            Assert.That(cartPage.LerTituloProduto(), Is.EqualTo(productTitle));
        }

        [Then(@"I verify the quantity is ""(.*)"" PO")]
        public void ThenIVerifyTheQuantityIsPO(string quantity)
        {
            Assert.That(cartPage.LerQuantidadeProduto(), Is.EqualTo(quantity));
        }

        [Then(@"I verify the product price ""(.*)"" in cart PO")]
        public void ThenIVerifyTheProductPriceInCartPO(string productPrice)
        {
            Assert.That(cartPage.LerPrecoProduto(), Is.EqualTo(productPrice));
        }
    }
}