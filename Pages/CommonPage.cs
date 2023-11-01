using OpenQA.Selenium;

namespace Pages
{
    public class CommonPage
    {
        protected IWebDriver driver;
        private IWebElement CabecalhoPagina => driver.FindElement(By.CssSelector("span.title"));
        private IWebElement IconeCarrinho => driver.FindElement(By.CssSelector("a.shopping_cart_link"));
        private IWebElement IconeCarrinhoNumero => driver.FindElement(By.CssSelector("a.shopping_cart_link span"));

        public CommonPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public String lerCabecalhoDaPagina()
        {
            return CabecalhoPagina.Text; // retorna o que estiver escrito no elemento
        }

        public bool IconeCarrinhoEstaPresente()
        {
            return IconeCarrinho.Displayed;
        }

        public String LerIconeCarrinhoNumero()
        {
            return IconeCarrinhoNumero.Text;
        }

        public void ClicarIconeCarrinho()
        {
            IconeCarrinho.Click();
        }
    }
}