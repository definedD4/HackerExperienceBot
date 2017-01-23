using HackerExperienceBot.Model;
using OpenQA.Selenium.Remote;

namespace HackerExperienceBot.Screens
{
    public class LoginScreen
    {
        private const string LoginPageUrl = @"https://legacy.hackerexperience.com/index";
        private const string UsernameTextId = @"login-username";
        private const string PasswordTextId = @"password";
        private const string LoginButtonId = @"login-submit";

        private readonly RemoteWebDriver m_Driver;

        public LoginCreditientials LoginCreditientials { get; }

        public LoginScreen(RemoteWebDriver driver, LoginCreditientials loginCreditientials)
        {
            m_Driver = driver;
            LoginCreditientials = loginCreditientials;

            m_Driver.Navigate().GoToUrl(LoginPageUrl);
        }

        public void EnterCreditientials()
        {
            m_Driver.FindElementById(UsernameTextId).SendKeys(LoginCreditientials.Username);
            m_Driver.FindElementById(PasswordTextId).SendKeys(LoginCreditientials.Password);
        }

        public void PressLoginButton()
        {
            m_Driver.FindElementById(LoginButtonId).Click();
        }
    }
}