using MailSender.lib.Interfaces;
using MailSenderApp.lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace MailSenderApp.ViewModels
{
    class StatisticViewModel: ViewModel
    {
        private readonly IStatistic _Statistic;

        public int MailsSendedCount => _Statistic.SendedMailsCount;

        //public int SendersCount => _Statistic.SendersCount;

        //public int RecipientsCount => _Statistic.RecipientsCount;

        public TimeSpan UpTime => _Statistic.UpTime;

        public StatisticViewModel(IStatistic Statistic)
        {
            _Statistic = Statistic;

            var timer = new Timer(100);
            timer.Elapsed += (_, _) => OnPropertyChanged(nameof(UpTime));
            timer.Start();

            Statistic.SendedMailsCountChanged += (_, _) => OnPropertyChanged(nameof(MailsSendedCount));
        }
    }
}
