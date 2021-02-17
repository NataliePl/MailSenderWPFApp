using System.Windows;
using System.Net;
using System.Net.Mail;
using System;

namespace TestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var from = new MailAddress("n.plaksickaya@gmail.com", "From_Наталия");
            var to = new MailAddress("79214126446@yandex.ru", "To_Наталия");

            var message = new MailMessage(from, to);
            message.Subject = "Тестовое письмо";
            message.Body = "Текст тестового письма";

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
                MessageBox.Show("Почта успешно отправлена");
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
