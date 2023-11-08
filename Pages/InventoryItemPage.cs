using OpenQA.Selenium;

namespace Pages
{
    public class InventoryItemPage : CommonPage
    {
        private IWebElement TituloProduto => driver.FindElement(By.CssSelector("div.inventory_details_name.large_size"));
        private IWebElement PrecoProduto => driver.FindElement(By.CssSelector("div.inventory_details_price"));
        private IWebElement BotaoAdicionarNoCarrinho => driver.FindElement(By.CssSelector(".btn.btn_primary.btn_small.btn_inventory"));

        public InventoryItemPage(IWebDriver driver) : base(driver) { }

        public String LerTituloProduto()
        {
            return TituloProduto.Text;
        }

        public String LerPrecoProduto()
        {
            return PrecoProduto.Text;
        }

        public void AdicionarNoCarrinho()
        {
            BotaoAdicionarNoCarrinho.Click();
        }
    }
}