using MailSenderApp.lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSenderApp.ViewModels
{
    internal class MainWindowViewModel: ViewModel
    {
        private string _Title = "Почтовый !";

        public string Title { get => _Title; set => Set(ref _Title, value); }

        private string _Status = "Готов к работе!!!";

        public string Status { get => _Status; set => Set(ref _Status, value); }
    }
}
