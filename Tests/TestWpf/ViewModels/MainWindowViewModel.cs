using MailSenderApp.lib.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWpf.ViewModels
{
    class MainWindowViewModel : ViewModel
    {
        private string _Title = "Тестовое название окна";
        public string Title
        {
            get => _Title;
            set
            {
                _Title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
    }
}
