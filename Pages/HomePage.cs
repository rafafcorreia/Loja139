using OpenQA.Selenium;

namespace Pages
{
    public class HomePage : CommonPage
    {
        private IWebElement CampoUsuario => driver.FindElement(By.Id("user-name"));
        private IWebElement CampoSenha => driver.FindElement(By.Id("password"));
        private IWebElement BotaoLogin => driver.FindElement(By.Id("login-button"));
        
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public void Logar(String user, String password)
        {
            CampoUsuario.SendKeys(user);
            CampoSenha.SendKeys(password);
        }

        public void CliclarBotaoLogin()
        {
            BotaoLogin.Click();
        }
    }
}