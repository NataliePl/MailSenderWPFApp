using MailSenderApp.Infrastructure;
using MailSenderApp.lib.ViewModels;
using MailSender.lib.Commands;
using MailSenderApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MailSender.lib.Interfaces;

namespace MailSenderApp.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        private string _Title = "Почтовый !";

        private readonly ServersRepository _Servers;
        private readonly IMailService _MailService;

        public string Title { get => _Title; set => Set(ref _Title, value); }

        private string _Status = "Готов к работе!!!";

        public string Status { get => _Status; set => Set(ref _Status, value); }

        public ObservableCollection<Server> Servers { get; } = new();

        private ICommand _LoadServersCommand;

        public ICommand LoadServersCommand => _LoadServersCommand
            ??= new LambdaCommand(OnLoadServersCommandExecuted, CanLoadServersCommandExecute);

        private bool CanLoadServersCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadServersCommandExecuted(object p)
        {
            LoadServers();
        }

        private ICommand _SendEMailCommand;

        public ICommand SendEmailCommand => _SendEMailCommand
            ??= new LambdaCommand(OnSendEmailCommandExecuted, CanSendEmailCommandExecute);

        private bool CanSendEmailCommandExecute(object p) => Servers.Count == 0;

        private void OnSendEmailCommandExecuted(object p)
        {
            _MailService.SendEMail("Иванов", "Петров", "Тема", "Тело письма");
        }

        public MainWindowViewModel(ServersRepository Servers, IMailService MailService)
        {
            _Servers = Servers;
            _MailService = MailService;
        }

        private void LoadServers()
        {
            foreach (var server in _Servers.GetAll())
                Servers.Add(server);
        }
    }
}
