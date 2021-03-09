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
using MailSenderApp.Infrastructure.Services;
using System.Windows;

namespace MailSenderApp.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        #region Title

        private string _Title = "Почтовый рассыльщик";
        public string Title { get => _Title; set => Set(ref _Title, value); }

        #endregion

        private readonly ServersRepository _Servers;

        private readonly RecipientsRepository _Recipients;

        private readonly SendersRepository _Senders;

        private readonly IMailService _MailService;

        public MainWindowViewModel(ServersRepository Servers, SendersRepository Senders, RecipientsRepository Recipients, IMailService MailService)
        {
            _Servers = Servers;
            _Senders = Senders;
            _Recipients = Recipients;
            _MailService = MailService;

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
        }

        #region Контрол серверов
        private string _ToolServersTitle = "Сервера";
        public string ToolServersTitle { get => _ToolServersTitle; set => Set(ref _ToolServersTitle, value); }

        private string _ToolRecipientsTitle = "Получатели";
        public string ToolRecipientsTitle { get => _ToolServersTitle; set => Set(ref _ToolServersTitle, value); }

        private string _ToolSendersTitle = "Отправители";
        public string ToolSendersTitle { get => _ToolSendersTitle; set => Set(ref _ToolSendersTitle, value); }

        #endregion


        #region Статус бар
        private string _Status = "Готов к работе!!!";

        public string Status { get => _Status; set => Set(ref _Status, value); }
        #endregion

        #region Сервера тулбара
        public ObservableCollection<Server> Servers { get; } = new();
        public ObservableCollection<Sender> Senders { get; } = new();

        private ICommand _LoadServersCommand;

        public ICommand LoadServersCommand => _LoadServersCommand
            ??= new LambdaCommand(OnLoadServersCommandExecuted, CanLoadServersCommandExecute);

        private bool CanLoadServersCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadServersCommandExecuted(object p)
        {
            LoadServers();
        }

        private void LoadServers()
        {
            foreach (var server in _Servers.GetAll())
                Servers.Add(server);

            foreach (var sender in _Senders.GetAll())
                Senders.Add(sender);
        }

        private ICommand _AddServerCommand;
        public ICommand AddServerCommand => _AddServerCommand
            ??= new LambdaCommand(AddServerCommandExecuted, CanAddServerExecute);

        private bool CanAddServerExecute(object p) => true;
        private void AddServerCommandExecuted(object p)
        {
            _Servers.Add((Server)p);
        }
        #endregion

        #region Команда Отправка почты
        private ICommand _SendEMailCommand;

        public ICommand SendEmailCommand => _SendEMailCommand
            ??= new LambdaCommand(OnSendEmailCommandExecuted, CanSendEmailCommandExecute);

        private bool CanSendEmailCommandExecute(object p) => Servers.Count == 0;

        private void OnSendEmailCommandExecuted(object p)
        {
            _MailService.SendEMail("Иванов", "Петров", "Тема", "Тело письма");
        }
        #endregion


        #region Загрузка получателей
        public ObservableCollection<Recipient> Recipients { get; } = new();

        private ICommand _LoadRecipientsCommand;
        public ICommand LoadRecipientsCommand => _LoadRecipientsCommand
            ??= new LambdaCommand(OnLoadRecipientsCommandExecuted, CanLoadRecipientsCommandExecute);

        private bool CanLoadRecipientsCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadRecipientsCommandExecuted(object p)
        {
            LoadRecipients();
        }
        private void LoadRecipients()
        {
            foreach (var recipient in _Recipients.GetAll())
                _Recipients.Add(recipient);
        }
        #endregion

        #region Загрузка отправителей
        

        private ICommand _LoadSendersCommand;
        public ICommand LoadSendersCommand => _LoadSendersCommand
            ??= new LambdaCommand(OnLoadSendersCommandExecuted, CanLoadSendersCommandExecute);

        private bool CanLoadSendersCommandExecute(object p) => true;

        private void OnLoadSendersCommandExecuted(object p)
        {
            LoadSenders();
        }
        private void LoadSenders()
        {
            foreach (var sender in _Senders.GetAll())
                _Senders.Add(sender);
        }
        #endregion

        private ICommand _OpenAddServerWindowCommand;

        public ICommand OpenAddServerWindowCommand => _OpenAddServerWindowCommand
            ??= new LambdaCommand(OpenAddServerWindowCommandExecuted, CanLoadRecipientsCommandExecute);

        private void OpenAddServerWindowCommandExecuted(object p)
        {
            var serverEditDialogViewModel = new ServerEditDialogViewModel();

            var displayRootRegistry = (Application.Current as App).displayRootRegistry;

            displayRootRegistry.ShowPresentation(serverEditDialogViewModel);
        }
        public ICommand CloseAppCommand { get; }
        private bool CanCloseAppCommandExecute(object p)
        {
            return true;
        }
        private void OnCloseAppCommandExecuted (object p)
        {
            Application.Current.Shutdown();
        }
    }
}
