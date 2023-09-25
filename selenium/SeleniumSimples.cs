// 1 - Namespace ~ Pacote ~ Grupo de Classe ~ Workspace
namespace Selenium;

// 2 - Bibliotecas ~ Dependências
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

// 3 - Classe
public class AdicionarProdutoNoCarrinhoTest
{
  private IWebDriver driver;

  // Funções e Métodos
  [SetUp]
  public void SetUp()
  {
    new DriverManager().SetUpDriver(new ChromeConfig()); // Configuração do WebDriverManager
    driver = new ChromeDriver();
    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(10000);
    driver.Manage().Window.Maximize();
  }
  [TearDown]
  protected void TearDown()
  {
    driver.Quit();
  }
  [Test]
  [TestCase("standard_user")]
  [TestCase("locked_out_user")]
  public void selecionarProdutoWebDriver(String username)
  {
    driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    driver.FindElement(By.Id("user-name")).SendKeys(username);
    driver.FindElement(By.Name("password")).SendKeys("secret_sauce");
    driver.FindElement(By.CssSelector("input.submit-button.btn_action")).Click();
    Assert.That(driver.FindElement(By.CssSelector("span.title")).Text, Is.EqualTo("Products"));
    Thread.Sleep(2000);
  }

  public static IEnumerable<TestCaseData> getTestData()
  {
    using (var reader = new StreamReader(@"C:\testspace\Loja139\fixtures\massa.csv"))
    {
      // Pula a primeira linha com os cabeçahos
      reader.ReadLine();

      while (!reader.EndOfStream)
      {
        var line = reader.ReadLine();
        var values = line.Split(",");

        yield return new TestCaseData(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));
      }
    }

  }

  [Test, TestCaseSource("getTestData")]
  public void testSomarMassa(String username)
  {
    driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    driver.FindElement(By.Id("user-name")).SendKeys(username);
    driver.FindElement(By.Name("password")).SendKeys("secret_sauce");
    driver.FindElement(By.CssSelector("input.submit-button.btn_action")).Click();
    Assert.That(driver.FindElement(By.CssSelector("span.title")).Text, Is.EqualTo("Products"));
    Thread.Sleep(2000);
  }

} // fim da classe