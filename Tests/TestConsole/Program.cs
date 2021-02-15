using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var from = new MailAddress("n.plaksickaya@yandex.ru", "From_Наталия");
            var to = new MailAddress("n.plaksickaya@gmail.com", "To_Наталия");

            var message = new MailMessage(from, to);
            message.Subject = "Тестовое письмо";
            message.Body = "Текст тестового письма";

            var client = new SmtpClient("smtp.yandex.ru", 25);
            client.EnableSsl = true;

            client.Credentials = new NetworkCredential
            {
                UserName = "n.plaksickaya",
                //SecurePassword = "8E3ER5ereme0",
                Password = "8E3ER5ereme0"
            };

            client.Send(message);
        }
    }
}
