using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//Плаксицкая
//1.Требуется создать свой собственный проект приложения (новое решение)
//2.Добавить проект в систему контроля версий
//3. Зарегистрироваться на GitHub.com (если учётной записи там ещё нет)
//4.Выгрузить созданный репозиторий в открытый репозиторий на github.com
//5. Создать тестовый WPF-проект приложения с окном, обеспечивающим отправку почты
//1. Обеспечить возможность ввода адреса получателя
//2. Обеспечить ввод адреса отправителя
//3. Обеспечить ввод параметров почтового сервера (адрес и порт, использовать/нет ssl)
//4.Обеспечить возможность ввода имени пользователя и пароля для сервера
//6. Разметку окна постараться структурировать с применением панелей контейнеров-компоновки.
//7. Реализовать стилизацию интерфейса

namespace MailSenderApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<String, int> portsOfMailServer = new Dictionary<string, int>();

        public MainWindow()
        {
            InitializeComponent();
            portsOfMailServer.Add("smtp.gmail.com", 25);
            portsOfMailServer.Add("smtp.yandex.ru", 25);
            portsOfMailServer.Add("smtp.mail.ru", 25);
        }

        private void MenuItem_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ServerComboBox_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}
