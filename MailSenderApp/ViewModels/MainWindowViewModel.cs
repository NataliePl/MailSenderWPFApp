using MailSenderApp.Infrastructure;
using MailSenderApp.lib.ViewModels;
using MailSenderApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApp.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        private string _Title = "Почтовый !";

        private readonly ServersRepository _Servers;

        public string Title { get => _Title; set => Set(ref _Title, value); }

        private string _Status = "Готов к работе!!!";

        public string Status { get => _Status; set => Set(ref _Status, value); }

        public ObservableCollection<Server> Servers { get; } = new();

        public MainWindowViewModel(ServersRepository Servers)
        {
            _Servers = Servers;
        }

        private void LoadServers()
        {
            foreach (var server in _Servers.GetAll())
                Servers.Add(server);
        }
    }
}
