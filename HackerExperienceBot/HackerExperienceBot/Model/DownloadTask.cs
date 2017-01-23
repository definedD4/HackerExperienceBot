using System;

namespace HackerExperienceBot.Model
{
    public class DownloadTask : Task
    {
        public IpAdress SourceAdress { get; }
        public SoftwareDef Software { get; }

        public DownloadTask(int pid, bool finished, TimeSpan timeLeft, IpAdress sourceAdress, SoftwareDef software) : base(pid, finished, timeLeft)
        {
            SourceAdress = sourceAdress;
            Software = software;
        }

        public void Complete()
        {
            if (Finished)
            {
                throw new NotImplementedException();
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        public override string ToString()
        {
            return
                $"(Download PID: {PID}, Time left: {TimeLeft}, Finished: {Finished}, Software: {Software}, Ip: {SourceAdress})";
        }
    }
}