using OpenQA.Selenium;

namespace Pages
{
    public class InventoryPage : CommonPage
    {

        public InventoryPage(IWebDriver driver) : base(driver)
        {

        }

        public void CliclarNoProduto(String nomeProduto)
        {
            String mapeamento = $"img[alt=\"{nomeProduto}\"]";
            driver.FindElement(By.CssSelector(mapeamento)).Click();
        }
    }
}