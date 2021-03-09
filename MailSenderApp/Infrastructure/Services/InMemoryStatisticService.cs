using MailSender.lib.Interfaces;
using MailSenderApp.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;
using MailSenderApp.lib.ViewModels;

namespace MailSenderApp.Infrastructure.Services
{
    internal class InMemoryStatisticService : IStatistic
    {
        private int _SendedMailsCount;

        

        public int SendedMailsCount => _SendedMailsCount;
        public event EventHandler SendedMailsCountChanged;
        //public int SendersCount => TestData.Senders.Count();

        //public int RecipientsCount => TestData.Recipients.Count();

        private readonly Stopwatch _StopwatchTimer = Stopwatch.StartNew();
        public TimeSpan UpTime => _StopwatchTimer.Elapsed;

        private Timer _Timer;

        public void MailSended() 
            {
            _SendedMailsCount++;
            SendedMailsCountChanged?.Invoke(this, EventArgs.Empty);
            }
            


        //public InMemoryStatisticService()
        //{
        //    _Timer = new Timer(100);
        //    _Timer.Elapsed += OnTimerElapsed;
        //}

        //private void OnTimerElapsed(object Sender, ElapsedEventArgs E)
        //{
        //    OnPropertyChanged(nameof(UpTime));
        //}
    }
}
