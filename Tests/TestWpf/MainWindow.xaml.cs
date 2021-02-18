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
