using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HackerExperienceBot.Model;
using HackerExperienceBot.Screens;
using OpenQA.Selenium.Chrome;

namespace HackerExperienceBot
{
    class Program
    {
        static void Main(string[] args)
        {
            var cred = new LoginCreditientials("DarKKsd", "BigMac_225");

            var driver = new ChromeDriver();

            var l = new LoginScreen(driver, cred);

            l.EnterCreditientials();

            Console.WriteLine("Solve captcha");
            Console.ReadKey();

            l.PressLoginButton();

            var t = new TaskManagerScreen(driver);

            foreach (var task in t.ParseTasks())
            {
                Console.WriteLine($"{task}");
            }

            Console.ReadKey();
        }
    }
}
