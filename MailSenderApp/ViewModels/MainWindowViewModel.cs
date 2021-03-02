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

        private readonly IMailService _MailService;

        public MainWindowViewModel(ServersRepository Servers, IMailService MailService)
        {
            _Servers = Servers;
            _MailService = MailService;

            CloseAppCommand = new LambdaCommand(OnCloseAppCommandExecuted, CanCloseAppCommandExecute);
        }

        #region Контрол серверов
        private string _ToolServersTitle = "Сервера";
        public string ToolServersTitle { get => _ToolServersTitle; set => Set(ref _ToolServersTitle, value); }

        #endregion


        #region Статус бар
        private string _Status = "Готов к работе!!!";

        public string Status { get => _Status; set => Set(ref _Status, value); }
        #endregion

        #region Загрузка серверов
        public ObservableCollection<Server> Servers { get; } = new();

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


        private ICommand _AddServerCommand;

        public ICommand AddServerCommand => _AddServerCommand
            ??= new LambdaCommand(AddServerCommandExecuted, CanAddServerExecute);

        private bool CanAddServerExecute(object p) => true;
        private void AddServerCommandExecuted(object p)
        {           
            _Servers.Add((Server)p);            
        }

        #region Загрузка получателей
        public ObservableCollection<Recipient> Recipients { get; } = new();

        public ICommand LoadRecipientsCommand => _LoadServersCommand
            ??= new LambdaCommand(OnLoadRecipientsCommandExecuted, CanLoadRecipientsCommandExecute);

        private bool CanLoadRecipientsCommandExecute(object p) => Servers.Count == 0;

        private void OnLoadRecipientsCommandExecuted(object p)
        {
            //LoadServers();
        }

        private void LoadRecipients()
        {
            foreach (var recipient in _Recipients.GetAll())
                Recipients.Add(recipient);
        }
        #endregion

        private ICommand _OpenAddServerWindowCommand;

        public ICommand OpenAddServerWindowCommand => _OpenAddServerWindowCommand
            ??= new LambdaCommand(OpenAddServerWindowCommandExecuted, CanLoadRecipientsCommandExecute);

        private void OpenAddServerWindowCommandExecuted(object p)
        {
            var serverEditDialogViewModel = new ServerEditDialogViewModel();

            //MessageBox.Show("gfhgfd");

            var displayRootRegistry = (Application.Current as App).displayRootRegistry;

            displayRootRegistry.ShowPresentation(serverEditDialogViewModel);
        }
        //private void OpenAddServerWindow ()
        //{
            
        //}

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
