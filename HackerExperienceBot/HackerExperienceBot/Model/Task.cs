using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerExperienceBot.Model
{
    public abstract class Task
    {
        public int PID { get; }
        public bool Finished { get; } 
        public TimeSpan TimeLeft { get; }

        protected Task(int pid, bool finished, TimeSpan timeLeft)
        {
            PID = pid;
            Finished = finished;
            TimeLeft = timeLeft;
        }
    }
}
