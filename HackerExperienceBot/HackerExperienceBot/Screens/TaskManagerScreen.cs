using System;
using System.Collections.Generic;
using System.Linq;
using HackerExperienceBot.Model;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace HackerExperienceBot.Screens
{
    public class TaskManagerScreen
    {
        private const string TaskManagerPageUrl = @"https://legacy.hackerexperience.com/processes?page=all";

        private RemoteWebDriver m_Driver;

        public TaskManagerScreen(RemoteWebDriver driver)
        {
            m_Driver = driver;

            m_Driver.Navigate().GoToUrl(TaskManagerPageUrl);
        }

        public IEnumerable<Task> ParseTasks()
        {
            var lis = m_Driver.FindElementByCssSelector("ul.list").FindElements(By.TagName("li"));
            foreach (var li in lis)
            {
                var pid = int.Parse(li.FindElement(By.Name("pid")).GetAttribute("value"));
                var desc = li.FindElement(By.ClassName("proc-desc"));

                var ext = desc.FindElement(By.TagName("b")).Text.Split('.').Last();

                SoftwareType type;
                switch (ext)
                {
                    case "crc": type = SoftwareType.Cracker; break;
                    case "hash": type = SoftwareType.Hasher; break;
                    case "skr": type = SoftwareType.Seeker; break;
                    default: type = SoftwareType.Unknown; break;
                }

                SoftwareVersion ver;
                {
                    int verBeg = desc.Text.IndexOf("(", StringComparison.Ordinal);
                    int verEnd = desc.Text.IndexOf(")", StringComparison.Ordinal);
                    var verStr = desc.Text.Substring(verBeg + 1, verEnd - verBeg - 1);
                    var vers = verStr.Split('.');
                    int maj = int.Parse(vers[0]);
                    int min = int.Parse(vers[1]);
                    ver = new SoftwareVersion(maj, min);
                }
                var softDef = new SoftwareDef(type, ver);
                yield return new DownloadTask(pid, false, TimeSpan.Zero, new IpAdress(0, 0, 0, 0), softDef);
            }
        }
    }
}