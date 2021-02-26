using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
//Базовая модель представления для наследования всеми VM
namespace MailSenderApp.lib.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        //Представляет метод, который обрабатывает событие PropertyChanged, возникающее при изменении свойства компонента.
        protected virtual void OnPropertyChanged ([CallerMemberName] string PropertyName = null)
        {
            //new PropertyChangedEventArgs в которой указано имя изменившегося свойства
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T> (ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;

            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }
}
