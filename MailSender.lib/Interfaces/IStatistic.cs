using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.lib.Interfaces
{
    public interface IStatistic
    {
        int SendedMailsCount { get; }
        event EventHandler SendedMailsCountChanged;

        void MailSended();

        int SendersCount { get; }

        int RecipientsCount { get; }

        TimeSpan UpTime { get; }
    }
}
