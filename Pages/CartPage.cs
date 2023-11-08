using OpenQA.Selenium;

namespace Pages
{
    public class CartPage : CommonPage
    {
        private IWebElement TituloProduto => driver.FindElement(By.CssSelector("div.inventory_item_name"));
        private IWebElement PrecoProduto => driver.FindElement(By.CssSelector("div.inventory_item_price"));
        private IWebElement QuantidadeProduto => driver.FindElement(By.CssSelector("div.cart_quantity"));

        public CartPage(IWebDriver driver) : base(driver) { }

        public String LerTituloProduto()
        {
            return TituloProduto.Text;
        }

        public String LerPrecoProduto()
        {
            return PrecoProduto.Text;
        }

        public String LerQuantidadeProduto()
        {
            return QuantidadeProduto.Text;
        }
    }
}