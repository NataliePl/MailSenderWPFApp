using System.Windows;
using System.Net;
using System.Net.Mail;
using System;

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

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string fromEMail;
        MailAddress from;
        MailAddress to;
        public MainWindow()
        {
            InitializeComponent();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            fromEMail = LoginTB.Text + "@gmail.com";
            from = new MailAddress("n.plaksickaya@gmail.com", FromNameTB.Text);
            to = new MailAddress(EmailToTB.Text, ToName.Text);

            var message = new MailMessage(from, to);
            message.Subject = MessageThemeTB.Text;
            message.Body = MessageTextTB.Text;

            var client = new SmtpClient("smtp.gmail.com", 25);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential
            {
                UserName = LoginTB.Text,
                SecurePassword = PasswordTB.SecurePassword
            };
            try
            {
                client.Send(message);
                MessageBox.Show("Письмо успешно отправлено");
            }
            catch (SmtpException)
            {
                MessageBox.Show("Ошибка авторизации");
            }
            catch (TimeoutException)
            {
                MessageBox.Show("Ошибка адреса сервера");
            }

        }
    }
}
