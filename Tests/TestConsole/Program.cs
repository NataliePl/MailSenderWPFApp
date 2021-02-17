using System;
using System.Net;
using System.Net.Mail;

namespace TestConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            var to = new MailAddress("79214126446@yandex.ru", "From_Наталия");
            var from = new MailAddress("n.plaksickaya@gmail.com", "To_Наталия");

            var message = new MailMessage(from, to);
            message.Subject = "Тестовое письмо";
            message.Body = "Текст тестового письма";

            var client = new SmtpClient("smtp.gmail.com", 25);
            client.EnableSsl = true;
            //client.Timeout = 1000;
            client.Credentials = new NetworkCredential
            {
                UserName = "n.plaksickaya",
                Password = "..."
            };

            client.Send(message);
        }
    }
}
