namespace HackerExperienceBot.Model
{
    public class LoginCreditientials
    {
        public string Username { get; }
        public string Password { get; }

        public LoginCreditientials(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}